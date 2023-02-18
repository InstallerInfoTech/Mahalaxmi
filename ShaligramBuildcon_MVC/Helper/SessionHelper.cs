using Data.ShaligramBuildcon_MVC.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Helper
{
    public class SessionHelper
    {
        public static int EmployeeId
        {
            get
            {
                return HttpContext.Current.Session["EmployeeId"] == null ? 0 : (int)HttpContext.Current.Session["EmployeeId"];
            }
            set
            {
                HttpContext.Current.Session["EmployeeId"] = value;
            }
        }

        public static string EmployeeName
        {
            get
            {
                return HttpContext.Current.Session["EmployeeName"] == null ? "" : (string)HttpContext.Current.Session["EmployeeName"];
            }
            set
            {
                HttpContext.Current.Session["EmployeeName"] = value;
            }
        }

        public static string Password
        {
            get
            {
                return HttpContext.Current.Session["Password"] == null ? "" : (string)HttpContext.Current.Session["Password"];
            }
            set
            {
                HttpContext.Current.Session["Password"] = value;
            }
        }

        public static int EmployeeRoleId
        {
            get
            {
                return HttpContext.Current.Session["EmployeeRoleId"] == null ? 0 : (int)HttpContext.Current.Session["EmployeeRoleId"];
            }
            set
            {
                HttpContext.Current.Session["EmployeeRoleId"] = value;
            }
        }

        public static string EmployeeEmail
        {
            get
            {
                return HttpContext.Current.Session["EmployeeEmail"] == null ? "" : (string)HttpContext.Current.Session["EmployeeEmail"];
            }
            set
            {
                HttpContext.Current.Session["EmployeeEmail"] = value;
            }
        }

        public static bool IsSuperAdmin
        {
            get
            {
                return HttpContext.Current.Session["IsSuperAdmin"] != null &&
                       (bool)HttpContext.Current.Session["IsSuperAdmin"];
            }
            set { HttpContext.Current.Session["IsSuperAdmin"] = value; }
        }

        public static string UserPermissionRights
        {
            get
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(HttpContext.Current.Session["UserAccessPermissions"]);
            }
        }

      
        public static List<Menus> UserAccessPermissions
        {
            get
            {
                return HttpContext.Current.Session["UserAccessPermissions"] == null
                    ? new List<Menus>()
                    : HttpContext.Current.Session["UserAccessPermissions"] as
                        List<Menus>;
            }

            set { HttpContext.Current.Session["UserAccessPermissions"] = value; }
        }

        public static string EmployeeUserName
        {
            get
            {
                return HttpContext.Current.Session["EmployeeUserName"] == null ? "" : (string)HttpContext.Current.Session["EmployeeUserName"];
            }
            set
            {
                HttpContext.Current.Session["EmployeeUserName"] = value;
            }
        }
    }
}