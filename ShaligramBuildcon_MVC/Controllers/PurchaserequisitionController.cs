
using ShaligramBuildcon_MVC.Models;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using Data.ShaligramBuildcon_MVC.Repository;
using Kendo.Mvc.Extensions;

namespace ShaligramBuildcon_MVC.Controllers
{
    public class PurchaserequisitionController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
               
                    return (null);
                

               
            }

            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Create([DataSourceRequest] DataSourceRequest request)
        {
           

            return Json(null);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request)
        {

            return Json(null);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request)
        {
           

            return Json(null);
        }
    }
}