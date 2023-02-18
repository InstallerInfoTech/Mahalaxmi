using OfficeOpenXml;
using ShaligramBuildconConsole.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaligramBuildconConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spreadsheetBCCustomer = Path.Combine(Directory.GetCurrentDirectory(), "Prime Open Area Sheet.xlsx");
            var packageBCCustomer = new ExcelPackage(new FileInfo(spreadsheetBCCustomer));
            ExcelWorksheet workSheetBCCustomer = packageBCCustomer.Workbook.Worksheets[1];
            IEnumerable<OpenTerraceCustomModel> list = PopulateExcel(workSheetBCCustomer, true);

            //string connetionString = "data source=NODE_SERVER;initial catalog=BuildconPMSMVC_Live;user id=bhavik;password=sit@123;";
            //SqlConnection cnn;
            //SqlCommand command;
            //SqlDataReader dataReader;
            //string sql = "SELECT * FROM ProjectUnitPropertyDetail WHERE ProjectId = 2";
            //cnn = new SqlConnection(connetionString);
            //cnn.Open();
            //command = new SqlCommand(sql, cnn);
            //dataReader = command.ExecuteReader();
            //cnn.Close();

            BuildconPMSMVC_LiveEntities dbContext = GetDbContext();

            List<ProjectUnitPropertyDetail> listproperty = dbContext.ProjectUnitPropertyDetails.Where(m=>m.ProjectId == 2).ToList();

            foreach (var item in list)
            {
                ProjectUnitPropertyDetail obj = listproperty.FirstOrDefault(m => m.FlatNumber == item.FlatNo);
                //Update Shops.............

                obj.OpenTerraceAreaFt = item.OpenTerraceAreaFt;
                obj.OpenTerraceAreaYards = item.OpenTerraceAreaMtr;


                //Update Project Plans.........
                //if(item.SaleableArea == 105)
                //{
                //     obj.ProjectRelatedPlanId = 7;
                //}
                //else if(item.SaleableArea == 171)
                //{
                //    obj.ProjectRelatedPlanId = 2;
                //}
                //else if (item.SaleableArea == 155)
                //{
                //    obj.ProjectRelatedPlanId = 4;
                //}
                //else if (item.SaleableArea == 118)
                //{
                //    obj.ProjectRelatedPlanId = 1;
                //}
                dbContext.Entry(obj).State = EntityState.Modified;
                //dbContext.ProjectUnitPropertyDetails.
            }
            dbContext.SaveChanges();

        }

        public static BuildconPMSMVC_LiveEntities GetDbContext()
        {
            BuildconPMSMVC_LiveEntities context = new BuildconPMSMVC_LiveEntities();
            context.Configuration.ProxyCreationEnabled = false;
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            objectContext.CommandTimeout = int.MaxValue;
            return context;
        }

        private static IEnumerable<OpenTerraceCustomModel> PopulateExcel(ExcelWorksheet workSheet, bool firstRowHeader)
        {
            IList<OpenTerraceCustomModel> priceList = new List<OpenTerraceCustomModel>();

            if (workSheet != null)
            {
                Dictionary<string, int> header = new Dictionary<string, int>();

                for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
                {
                    //Assume the first row is the header. Then use the column match ups by name to determine the index.
                    //This will allow you to have the order of the columns change without any affect.

                    if (rowIndex == 1 && firstRowHeader)
                    {
                        header = ExcelHelper.GetExcelHeader(workSheet, rowIndex);
                    }
                    else
                    {
                        string FlatNo = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Flat No");
                        decimal? OpenAreaFt = ExcelHelper.ParseDecimalNullWorksheetValue(workSheet, header, rowIndex, "Open Terrace Area FT");
                        decimal? OpenAreaMtr = ExcelHelper.ParseDecimalNullWorksheetValue(workSheet, header, rowIndex, "Open Terrace Area Mtr");

                        priceList.Add(new OpenTerraceCustomModel
                        {
                            FlatNo = FlatNo,
                            OpenTerraceAreaFt = OpenAreaFt.Value,
                            OpenTerraceAreaMtr = OpenAreaMtr.Value
                        });
                    }
                }
            }

            return priceList;
        }

        public class CustomModel
        {
            public string ShopNo { get; set; }

            public decimal InsideArea { get; set; }

            public decimal TotalCarpetArea { get; set; }
        }

        public class OpenTerraceCustomModel
        {
            public string FlatNo { get; set; }

            public decimal OpenTerraceAreaFt { get; set; }

            public decimal OpenTerraceAreaMtr { get; set; }
        }

        public static class ExcelHelper
        {
            public static Dictionary<string, int> GetExcelHeader(ExcelWorksheet workSheet, int rowIndex)
            {
                Dictionary<string, int> header = new Dictionary<string, int>();

                if (workSheet != null)
                {
                    for (int columnIndex = workSheet.Dimension.Start.Column; columnIndex <= workSheet.Dimension.End.Column; columnIndex++)
                    {
                        if (workSheet.Cells[rowIndex, columnIndex].Value != null)
                        {
                            string columnName = workSheet.Cells[rowIndex, columnIndex].Value.ToString();

                            if (!header.ContainsKey(columnName) && !string.IsNullOrEmpty(columnName))
                            {
                                header.Add(columnName, columnIndex);
                            }
                        }
                    }
                }

                return header;
            }

            public static string ParseWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
            {
                string value = string.Empty;
                int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

                if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
                {
                    value = workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString();
                }

                return value;
            }


            public static decimal? ParseDecimalNullWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
            {
                decimal? value = null;
                int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

                if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
                {
                    value = Convert.ToDecimal(workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString());
                }

                return value;
            }

            public static int? ParseIntNullWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
            {
                int? value = null;
                int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

                if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
                {
                    value = Convert.ToInt32(workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString());
                }

                return value;
            }

            public static decimal? ParseFormulaValueWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
            {
                decimal? value = null;
                int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

                if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
                {
                    workSheet.Cells[rowIndex, columnIndex.Value].Calculate();
                    value = Convert.ToDecimal(workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString());
                }

                return value;
            }
        }
    }
}
