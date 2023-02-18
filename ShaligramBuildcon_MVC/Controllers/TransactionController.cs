using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.SignalR;
using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShaligramBuildcon_MVC.Controllers
{
    public class TransactionController : Controller
    {
       
        public ActionResult Index()
        {
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<CustomMemberModel> list = new List<CustomMemberModel>();
            list = context.Database.SqlQuery<CustomMemberModel>("GetAllActiveMembers").ToList();
            ViewData["activemembers"] = list;

            return View();
        }

        public ActionResult Create(int id = 0)
       {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                CustomTransactionModel model = new CustomTransactionModel();
            if (id > 0)
            {
                TempData["id"] = id;    
                model = context.Database.SqlQuery<CustomTransactionModel>("BindTranById @id",
                                                                        Utils.GetSQLParam("@id", SqlDbType.Int, id)
                                                                        ).FirstOrDefault();

            }
            return View("~/Views/Transaction/Create.cshtml",model);
        }

       

        public ActionResult GetMemberNo([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {

            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<CustomMemberModel> list = new List<CustomMemberModel>();
            list = context.Database.SqlQuery<CustomMemberModel>("GetMemberDropdown @id",
                  Utils.GetSQLParam("id", SqlDbType.Int, id)).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult BindNameBasedOnMobileNo([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {
            try
            {
                if (id > 0)
                {
                    Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                    List<Member> list = new List<Member>();
                    list = context.Database.SqlQuery<Member>("GetMemberDropdown @id",
                          Utils.GetSQLParam("id", SqlDbType.Int, id)).ToList();
                    return Json(new { AttributeName = list.FirstOrDefault().F_Name + " " + list.FirstOrDefault().L_Name }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { AttributeName = "" }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public ActionResult GetProductList([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {

            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<Product> list = new List<Product>();
            list = context.Database.SqlQuery<Product>("GetProductList").ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProductList1([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {
            if (id > 0)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
                List<Product> list = new List<Product>();
                list = context.Database.SqlQuery<Product>("GetProductListAsPerProductId @id",
                     Utils.GetSQLParam("id", SqlDbType.Int, id)).ToList();
                return Json(new { lbrrate = list.FirstOrDefault().Labor_Rate }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { lbrrate = 0 }, JsonRequestBehavior.AllowGet);
            //return Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetSubProductList([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {

            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<Sub_Product> list = new List<Sub_Product>();
            list = context.Database.SqlQuery<Sub_Product>("GetSubProductList").ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetSubProductList1([DataSourceRequest] DataSourceRequest request, int? id = 0)
        {

            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<Sub_Product> list = new List<Sub_Product>();
            list = context.Database.SqlQuery<Sub_Product>("GetSubProductList").ToList();
            return Json(new { lbrrate = list.FirstOrDefault().Labour_rate }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request, string name = "" , int ? productid = 0 , int subproductid = 0)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {

                    List<CustomTransactionModel> list = new List<CustomTransactionModel>();
                    list = context.Database.SqlQuery<CustomTransactionModel>("GetTranDetailsOnMembers @contact_no,@productid,@subproductid",
                                                                        Utils.GetSQLParam("contact_no", SqlDbType.VarChar, name),
                                                                        Utils.GetSQLParam("productid", SqlDbType.Int, productid),
                                                                        Utils.GetSQLParam("subproductid", SqlDbType.Int, subproductid)
                                                                        ).ToList();



                    return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }



                 


            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public ActionResult ReadGrid([DataSourceRequest] DataSourceRequest request, int? productid = 0, int? qty = 0, int? subproductid = 0)
       {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {

                    List<CustomTranDetails> list = new List<CustomTranDetails>();
                    if (productid > 0)
                    {
                        list = context.Database.SqlQuery<CustomTranDetails>("sp_getproduct_rm @product_id,@Qty,@id",
                                                                        Utils.GetSQLParam("product_id", SqlDbType.Int, productid),
                                                                        Utils.GetSQLParam("Qty", SqlDbType.Int, qty),
                                                                        Utils.GetSQLParam("id", SqlDbType.Int, Convert.ToInt32(TempData["id"]))
                                                                        ).ToList();
                    }
                    if (subproductid > 0)
                    {
                        list = context.Database.SqlQuery<CustomTranDetails>("sp_getsubproduct_rm @product_id,@Qty",
                                                                        Utils.GetSQLParam("product_id", SqlDbType.Int, subproductid),
                                                                        Utils.GetSQLParam("Qty", SqlDbType.Int, qty)
                                                                        ).ToList();
                    }



                    return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }






            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        //public ActionResult SaveTransaction([DataSourceRequest] DataSourceRequest request , int member_id, int product_id, int subproduct_id, int reqqty,Decimal totalwtgiven, DateTime orderdate, DateTime returndate,Decimal pclbrrate, Decimal Actlpclbrrate, Decimal totalactAmount, string data)
        public ActionResult SaveTransaction(DataSourceRequest request, CustomTransactionModel model)
        {
            try
            {

                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {
                    DbContextTransaction tran = context.Database.BeginTransaction();
                    var serializer = new JavaScriptSerializer();

                    string message = "";

                    IEnumerable<CustomTranDetails> Details = serializer.Deserialize<IEnumerable<CustomTranDetails>>(model.PRtoPOItemDetailTableString);
                 
                    message = context.Database.SqlQuery<string>("sp_saveTransaction @trxid,@member_id,@product_id,@subproduct_id,@reqqty,@totalwtgiven,@orderdate,@returndate,@pclbrrate,@Actlpclbrrate,@totalactAmount",
                                                                Utils.GetSQLParam("trxid", SqlDbType.Int, (object)model.Trx_id ?? DBNull.Value),
                                                               Utils.GetSQLParam("member_id", SqlDbType.Int, (object)model.Member_id ?? DBNull.Value),
                                                               Utils.GetSQLParam("product_id", SqlDbType.Int, (object)model.Product_id ?? DBNull.Value),
                                                               Utils.GetSQLParam("subproduct_id", SqlDbType.Int, (object)model.subproduct_id ?? DBNull.Value),
                                                               Utils.GetSQLParam("reqqty", SqlDbType.Int, (object)model.Required_Qty ?? DBNull.Value),
                                                               Utils.GetSQLParam("totalwtgiven", SqlDbType.Decimal, model.Total_Weight_given),
                                                               Utils.GetSQLParam("orderdate", SqlDbType.DateTime, model.Order_date),
                                                               Utils.GetSQLParam("returndate", SqlDbType.DateTime, model.Return_date),
                                                               Utils.GetSQLParam("pclbrrate", SqlDbType.Decimal, model.Piece_Labor_Rate),
                                                               Utils.GetSQLParam("Actlpclbrrate", SqlDbType.Decimal, model.Actual_piece_labor_rate),
                                                               Utils.GetSQLParam("totalactAmount", SqlDbType.Decimal, model.Total_Actual_Amount)
                                                               ).FirstOrDefault();

                    string[] msg1 = message.Split('|');
                    int headerid = Convert.ToInt32(msg1[0]);


                    foreach (var item in Details)
                    {
                        message = context.Database.SqlQuery<string>("sp_saveTransactionDetails @ID,@headerid,@productname,@type,@material,@ttlqty,@unittype,@Gqty,@pending,@reqQty",
                                                               Utils.GetSQLParam("ID", SqlDbType.Int, (object)item.Trxdetails_id ?? DBNull.Value),
                                                              Utils.GetSQLParam("headerid", SqlDbType.Int, (object)headerid ?? DBNull.Value),
                                                              Utils.GetSQLParam("productname", SqlDbType.VarChar, (object)item.product_name ?? DBNull.Value),
                                                              Utils.GetSQLParam("type", SqlDbType.VarChar, (object)item.type ?? DBNull.Value),
                                                              Utils.GetSQLParam("material", SqlDbType.VarChar, (object)item.Material ?? DBNull.Value),
                                                              Utils.GetSQLParam("ttlqty", SqlDbType.Int, item.Totalqty),
                                                              Utils.GetSQLParam("unittype", SqlDbType.VarChar, item.unit_type),
                                                              Utils.GetSQLParam("Gqty", SqlDbType.Int, item.Given_qty),
                                                              Utils.GetSQLParam("pending", SqlDbType.Bit, Convert.ToBoolean(item.status)),
                                                              Utils.GetSQLParam("reqQty", SqlDbType.Int, model.Required_Qty)
                                                              ).FirstOrDefault();
                    }
                    if (Convert.ToInt32(msg1[0]) == 0)
                    {
                        tran.Rollback();
                    }
                    else
                    {
                        tran.Commit();
                    }
                    return RedirectToAction("Index", "Transaction");

                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public ActionResult kendoDestroy([DataSourceRequest] DataSourceRequest request, CustomTransactionModel model)
        {
            ModelState.Clear();
            if (model.Trx_id > 0)
            {
                Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

                //var msg = context.DeleteProducts(product.Product_Id);


            }

            return RedirectToAction("Index");
        }

        public ActionResult DetailReadGrid([DataSourceRequest] DataSourceRequest request, int? Trx_id = 0)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {

                    List<CustomTranDetails> list = new List<CustomTranDetails>();

                    list = context.Database.SqlQuery<CustomTranDetails>("GetTransactionDetailsBasedOnMembers @trxid",
                                                                       Utils.GetSQLParam("trxid", SqlDbType.Int, Trx_id)).ToList();


                    return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }






            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, CustomTransactionModel model, int ? memberid = 0)

        {
          
            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                message = context.Database.SqlQuery<string>("UpdateTransacation @trxid,@totalwtrecievded,@recievedqty,@actualreturndate,@iscomplete",
                                                               Utils.GetSQLParam("trxid", SqlDbType.Int, (object)model.Trx_id ?? DBNull.Value),
                                                              Utils.GetSQLParam("totalwtrecievded", SqlDbType.Decimal, (object)model.Total_weight_recieved?? DBNull.Value),
                                                              Utils.GetSQLParam("recievedqty", SqlDbType.Int, (object)model.Recieved_qty ?? DBNull.Value),
                                                              Utils.GetSQLParam("actualreturndate", SqlDbType.DateTime, (object)model.Actual_return_date ?? DBNull.Value),
                                                              Utils.GetSQLParam("iscomplete", SqlDbType.Bit, (object)model.Is_completed ?? DBNull.Value)
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
        public ActionResult saveTranDetails([DataSourceRequest] DataSourceRequest request, CustomTranDetails model, int? memberid = 0)

        {

            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)  
            {
                message = context.Database.SqlQuery<string>("UpdateTransacationDetails @trxdetailid,@givenqty",
                                                               Utils.GetSQLParam("trxdetailid", SqlDbType.Int, (object)model.Trxdetails_id ?? DBNull.Value),
                                                              Utils.GetSQLParam("givenqty", SqlDbType.Decimal, (object)model.Given_qty ?? DBNull.Value)
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


//declare
//@productid int = 16,
//@subproductid int
//BEGIN
//select distinct PR.Required_qty from product P 
//inner join Product_RM_usage PR on pr.Product_id = P.Product_Id
//--inner join Raw_Material R on R.Rawmaterial_Id = PR.Rawmaterial_id
//inner join Product_Subproduct_relation PS on ps.Product_id = P.Product_Id where P.Product_Id = @productid and PR.Product_id = @productid and PS.Product_id=@productid
//END
