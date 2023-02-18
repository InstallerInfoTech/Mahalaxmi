using ShaligramBuildcon_MVC.App_Start;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShaligramBuildcon_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string connString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"];
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebapiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Start SqlDependency with application initialization
          //  SqlDependency.Start(connString);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
            CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            info.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
        }

        protected void Application_Error()
        {
            // Sets 404 HTTP exceptions to be handled via IIS (behavior is specified in the "httpErrors" section in the Web.config file)
            var error = Server.GetLastError();
            if ((error as HttpException)?.GetHttpCode() == 404)
            {
                Server.ClearError(); 
                Response.StatusCode = 404;
            }
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(connString);
        }
    }
}
