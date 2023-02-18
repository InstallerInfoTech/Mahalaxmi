using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShaligramBuildcon_MVC.Controllers
{
    public class SubProductController : Controller
    {
        public ActionResult Index()
        {
           
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            ViewData["Location"] = context.BindLocation().ToList();
            ViewData["RM"] = context.sp_RawMaterials().ToList();

            return View();
        }
        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context1 = new Mahalaxmi_HandicraftEntities())
                {

                    List<Sub_Product> list = new List<Sub_Product>();
                    list  = context1.Database.SqlQuery<Sub_Product>("sp_ReadSubProduct").ToList();

                    return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }

                //Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                //var result = context.Products.ToList().ToDataSourceResult(request);
                //return Json(new { result }, JsonRequestBehavior.AllowGet);

                //using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                //{

                //}




            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, Sub_Product model)

        {
            TempData["id"] = null;
            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                message = context.Database.SqlQuery<string>("Sp_SavesubProducts @subproductid,@Name,@Description,@SKU,@locationid,@labourrate,@unitid",
                                                                 Utils.GetSQLParam("subproductid", SqlDbType.Int, (object)model.SubProduct_Id ?? DBNull.Value),
                                                                Utils.GetSQLParam("Name", SqlDbType.VarChar, (object)model.Name ?? DBNull.Value),
                                                                Utils.GetSQLParam("Description", SqlDbType.VarChar, (object)model.Description ?? DBNull.Value),
                                                                Utils.GetSQLParam("SKU", SqlDbType.Int, (object)model.SKU ?? DBNull.Value),
                                                                Utils.GetSQLParam("locationid", SqlDbType.Int, (object)model.Location_id ?? DBNull.Value),
                                                                Utils.GetSQLParam("labourrate", SqlDbType.Int, model.Labour_rate),
                                                                Utils.GetSQLParam("unitid", SqlDbType.Int, 2)
                                                                ).FirstOrDefault();


                string[] msg1 = message.Split('|');
                if (Convert.ToInt32(msg1[0]) == 0)
                {
                    tran.Rollback();
                }
                else
                {
                    tran.Commit();
                    TempData["id"] = Convert.ToInt32(msg1[0]);

                }

            }
            TempData[Enums1.NotifyType.Success.GetDescription1()] = "Project saved Successfully.";
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadrealtionGrid([DataSourceRequest] DataSourceRequest request, int SubProduct_Id)
        {
            ModelState.Clear();
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

            List<Subproduct_RM_usage> list = new List<Subproduct_RM_usage>();
            list = context.Database.SqlQuery<Subproduct_RM_usage>("sp_SubProductRmRelation @SubProductid",
                                                                Utils.GetSQLParam("SubProductid", SqlDbType.Int, SubProduct_Id)
                                                                ).ToList();
            if (SubProduct_Id == 0)
            {
                TempData["SubProductid"] = Convert.ToInt32(TempData["id"]);
                TempData.Keep("id");
            }
            else
            {
                TempData["SubProductid"] = SubProduct_Id;
            }

            //List<GetProductRMRelation1_Result> result = new List<GetProductRMRelation1_Result>() ;
            //result = context.GetProductRMRelation1(productid).ToList() ;  

            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveSubProductChild([DataSourceRequest] DataSourceRequest request, Subproduct_RM_usage model)

        {
            ModelState.Clear();
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            string message = "";
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
               

                List<Subproduct_RM_usage> list = new List<Subproduct_RM_usage>();
                message = context.Database.SqlQuery<string>("Sp_SaveSubProductsRmRelationsForSubProducts @spmrid,@SubProductid,@RMId,@RequiredQty",
                                                                    Utils.GetSQLParam("spmrid", SqlDbType.Int, model.SPRM_id),
                                                                    Utils.GetSQLParam("SubProductid", SqlDbType.Int, Convert.ToInt32(TempData["SubProductid"])),
                                                                    Utils.GetSQLParam("RMId", SqlDbType.Int, model.Rawmaterial_id),
                                                                    Utils.GetSQLParam("RequiredQty", SqlDbType.Decimal, model.Required_qty)
                                                                    ).FirstOrDefault();
                TempData.Keep("SubProductid");
                if (message == "")
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }

                //if (id.FirstOrDefault() > 0)
                //{
                //    tran.Commit();
                //}
                //else
                //{
                //    tran.Rollback();
                //}

            }
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteSubProductChild([DataSourceRequest] DataSourceRequest request, int? PRMID)
        {
            ModelState.Clear();
            string message = "";
            if (PRMID != null)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                DbContextTransaction tran = context.Database.BeginTransaction();

                List<Subproduct_RM_usage> list = new List<Subproduct_RM_usage>();
                message = context.Database.SqlQuery<string>("DeleteSubProductRmUsage @id",
                                                                    Utils.GetSQLParam("id", SqlDbType.Int, PRMID)
                                                                    ).FirstOrDefault();

                if (message == "")
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }



            }

            return RedirectToAction("Index");
        }
         
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult kendoDestroy([DataSourceRequest] DataSourceRequest request, Sub_Product model)
        {
            ModelState.Clear();
            string message = "";
            if (model != null)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                DbContextTransaction tran = context.Database.BeginTransaction();

                List<Sub_Product> list = new List<Sub_Product>();
                message = context.Database.SqlQuery<string>("DeletSubProduct @id",
                                                                    Utils.GetSQLParam("id", SqlDbType.Int, model.SubProduct_Id)
                                                                    ).FirstOrDefault();

                if (message == "")
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }



            }

            return RedirectToAction("Index");

           
        }


    }
}