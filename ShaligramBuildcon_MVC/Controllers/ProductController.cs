
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
    public class ProductController : Controller
       
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
            ViewData["RM"] = context.sp_RawMaterials().ToList();
            ViewData["SubProduct"] = context.sp_subproduct().ToList();
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
      {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context1 = new Mahalaxmi_HandicraftEntities())
                {


                    //List<sp_Products_Result> products = new List<sp_Products_Result>();
                    ////SP_Products_Result sP_Products_Result = new SP_Products_Result();
                    var result = context1.sp_Products().Select(p => new ProductViewModel
                    {
                        Product_Id = p.Product_Id,
                        Name = p.Name,
                        Description = p.Description,
                        SKU = p.SKU,
                        Category_id = p.Category_id,
                        Location_id = p.Location_id,
                        Labor_Rate = p.Labor_Rate
                        
                    }).ToList();
                    //   products = context1.Database.SqlQuery("SP_Products").ToList();
                    //
                    return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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

        public ActionResult Productsubproductrealtionread([DataSourceRequest] DataSourceRequest request ,int productid)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {
                    List<Product_Subproduct_relation> list = new List<Product_Subproduct_relation>();
                  list  = context.Database.SqlQuery<Product_Subproduct_relation>("sp_ProductSubProductRelation @Productid",
                                                                Utils.GetSQLParam("Productid", SqlDbType.Int, productid)
                                                                ).ToList();

                    if (productid == 0)
                    {
                        TempData["productid"] = Convert.ToInt32(TempData["id"]);
                        TempData.Keep("id");
                    }
                    else
                    {
                        TempData["productid"] = productid;
                    }
                   
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
        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, ProductViewModel model)
            
        {
            TempData["id"] = null;
            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                message  = context.Database.SqlQuery<string>("Sp_SaveProducts @productid,@Name,@Description,@SKU,@Categoryid,@locationid,@labourrate",
                                                                 Utils.GetSQLParam("productid", SqlDbType.Int, (object)model.Product_Id ?? DBNull.Value),
                                                                Utils.GetSQLParam("Name", SqlDbType.VarChar, (object)model.Name ?? DBNull.Value),
                                                                Utils.GetSQLParam("Description", SqlDbType.VarChar, (object)model.Description?? DBNull.Value),
                                                                Utils.GetSQLParam("SKU", SqlDbType.Int, (object) model.SKU ?? DBNull.Value),
                                                                Utils.GetSQLParam("Categoryid", SqlDbType.Int, (object)model.Category_id ?? DBNull.Value),
                                                                Utils.GetSQLParam("locationid", SqlDbType.Int, model.Location_id),
                                                                Utils.GetSQLParam("labourrate", SqlDbType.Int, model.Labor_Rate)
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadrealtionGridSave([DataSourceRequest] DataSourceRequest request, ProductRMRelation model)

        {
            ModelState.Clear();
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            //DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                var id = context.Sp_SaveProductsRmRelations(model.PRM_id, Convert.ToInt32(TempData["Productid"]), model.Rawmaterial_id, model.Required_qty);
                TempData.Keep("Productid");

                //if (id.FirstOrDefault() > 0)
                //{
                //    tran.Commit();
                //}
                //else
                //{
                //    tran.Rollback();
                //}
               
            }
            return Json(request,JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult productsubproductrelsave([DataSourceRequest] DataSourceRequest request, ProductSubProductRelations model)
        {
            ModelState.Clear();
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            //DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                var id = context.Sp_SaveSubProductsRmRelations(model.PSR_id, Convert.ToInt32(TempData["productid"]), model.SubProduct_id, model.Required_qty);
                TempData.Keep("productid");

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
        public ActionResult kendoDestroy([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            ModelState.Clear();
            if (product != null)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
               
                var msg = context.DeleteProducts(product.Product_Id);
               

            }

            return RedirectToAction("Index");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadrealtionDestroy([DataSourceRequest] DataSourceRequest request, int? PRMID)
        {
            ModelState.Clear();
            if (PRMID != null)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

                var msg = context.DeleteProductsRmRelation(PRMID);


            }

            return RedirectToAction("Index");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult productsubproductrelDelete([DataSourceRequest] DataSourceRequest request, int? PRSID)
        {
            ModelState.Clear();
            if (PRSID != null)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

                var msg = context.DeleteProductsSubproductRelation(PRSID);


            }

            return RedirectToAction("Index");
        }

        public ActionResult AddRawmaterial()
        {
            

            return PartialView("_partialrawmaterial");
        }

        public ActionResult ReadrealtionGrid([DataSourceRequest] DataSourceRequest request, int productid)
        {
            ModelState.Clear();
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
           
            List<ProductRMRelation> list = new List<ProductRMRelation>();
            list = context.Database.SqlQuery<ProductRMRelation>("sp_ProductRmRelation @Productid",
                                                                Utils.GetSQLParam("Productid", SqlDbType.Int, productid)
                                                                ).ToList();
            if (productid == 0)
            {
            TempData["Productid"] = Convert.ToInt32(TempData["id"]);
                TempData.Keep("id");
            }
            else
            {
                TempData["Productid"] = productid;
            }

            //List<GetProductRMRelation1_Result> result = new List<GetProductRMRelation1_Result>() ;
            //result = context.GetProductRMRelation1(productid).ToList() ;  

            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
    }
}