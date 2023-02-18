
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR.Hubs;
using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ShaligramBuildcon_MVC.Controllers
{
    public class RawMaterialController : Controller
       
    {
        //readonly GenericRepository<Product_RM_usage> _dbrepository = new GenericRepository<Product_RM_usage>();
        //readonly GenericRepository<Raw_Material> _dbrepositoryraw = new GenericRepository<Raw_Material>();
        public ActionResult Index()
        {
            TempData["Productid"] = null;
            TempData["productid"] = null;
            TempData["id"] = null;
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

            ViewData["categories"] = context.BindCategory().ToList();
            ViewData["Location"] = context.BindLocation().ToList();
            ViewData["categories"] = context.BindCategory().ToList();
            ViewData["Location"] = context.BindLocation().ToList();

            List<Measurement_unit> list = new List<Measurement_unit>();
            list = context.Database.SqlQuery<Measurement_unit>("unittyppe").ToList();
            ViewData["unittype"] = list;
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {
                    List<Raw_Material> list = new List<Raw_Material>();
                    list = context.Database.SqlQuery<Raw_Material>("GetRawMaterialList"
                                                                  ).ToList();

                   

                    //   products = context1.Database.SqlQuery("SP_Products").ToList();
                    //
                    return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }






            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, Raw_Material model)

        {
            
            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                message = context.Database.SqlQuery<string>("SaveRawMaterial @id,@name,@description,@sku,@unitid,@categoryid,@Location_id",
                                                                 Utils.GetSQLParam("id", SqlDbType.Int, (object)model.Rawmaterial_Id ?? DBNull.Value),
                                                                Utils.GetSQLParam("name", SqlDbType.VarChar, (object)model.Name ?? DBNull.Value),
                                                                Utils.GetSQLParam("description", SqlDbType.VarChar, (object)model.Description ?? DBNull.Value),
                                                                Utils.GetSQLParam("sku", SqlDbType.Int, (object)model.SKU ?? DBNull.Value),
                                                                Utils.GetSQLParam("unitid", SqlDbType.Int, (object)model.unit_id?? DBNull.Value),
                                                                Utils.GetSQLParam("categoryid", SqlDbType.Int, model.Category_id),
                                                                Utils.GetSQLParam("Location_id", SqlDbType.Int, model.Location_id)
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
            
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult kendoDestroy([DataSourceRequest] DataSourceRequest request, Raw_Material model)

        {

            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model.Rawmaterial_Id > 0)
            {
                message = context.Database.SqlQuery<string>("DeketeRawMaterial @id",
                                                                 Utils.GetSQLParam("id", SqlDbType.Int, (object)model.Rawmaterial_Id ?? DBNull.Value)
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

            return Json(request, JsonRequestBehavior.AllowGet);
        }


    }
}