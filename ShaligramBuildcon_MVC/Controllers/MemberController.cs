
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
using Member = ShaligramBuildcon_MVC.Models.Member;

namespace ShaligramBuildcon_MVC.Controllers
{
    public class MemberController : Controller
       
    {
        //readonly GenericRepository<Product_RM_usage> _dbrepository = new GenericRepository<Product_RM_usage>();
        //readonly GenericRepository<Raw_Material> _dbrepositoryraw = new GenericRepository<Raw_Material>();
        public ActionResult Index()
        {
           
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();

           

            List<Memeber_Category> list = new List<Memeber_Category>();
            list = context.Database.SqlQuery<Memeber_Category>("GetMemberCategory").ToList();
            ViewData["Memeber_Category"] = list;
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                ModelState.Clear();
                using (Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities())
                {
                    List<Member> list = new List<Member>();
                    list = context.Database.SqlQuery<Member>("GetAllMemberList"
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
        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, Member model)

        {
            
            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model != null)
            {
                message = context.Database.SqlQuery<string>("SaveMembers @id,@fname,@lname,@contactno,@alternatecontactno,@address,@aadhar,@depositeamt,@membercategpryid",
                                                                 Utils.GetSQLParam("id", SqlDbType.Int, (object)model.Member_id ?? DBNull.Value),
                                                                Utils.GetSQLParam("fname", SqlDbType.VarChar, (object)model.F_Name ?? DBNull.Value),
                                                                Utils.GetSQLParam("lname", SqlDbType.VarChar, (object)model.L_Name ?? DBNull.Value),
                                                                Utils.GetSQLParam("contactno", SqlDbType.VarChar, (object)model.Contact_no ?? DBNull.Value),
                                                                Utils.GetSQLParam("alternatecontactno", SqlDbType.VarChar, (object)model.Alternate_conatact_no?? DBNull.Value),
                                                                Utils.GetSQLParam("address", SqlDbType.VarChar, (object)model.Address ?? DBNull.Value),
                                                                Utils.GetSQLParam("aadhar", SqlDbType.VarChar, (Object)model.Aadhar ?? DBNull.Value),
                                                                Utils.GetSQLParam("depositeamt", SqlDbType.VarChar, (Object)model.Deposit_Amount ?? DBNull.Value),
                                                                Utils.GetSQLParam("membercategpryid", SqlDbType.VarChar, (Object)model.member_Category_id ?? DBNull.Value)
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
        public ActionResult kendoDestroy([DataSourceRequest] DataSourceRequest request, Member model)

        {

            ModelState.Clear();
            string message = "";
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            DbContextTransaction tran = context.Database.BeginTransaction();
            if (model.Member_id > 0)
            {
                message = context.Database.SqlQuery<string>("DeleteMembers @id",
                                                                 Utils.GetSQLParam("id", SqlDbType.Int, (object)model.Member_id ?? DBNull.Value)
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