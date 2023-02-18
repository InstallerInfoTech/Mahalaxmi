using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace ShaligramBuildcon_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Css
            bundles.Add(new StyleBundle("~/Content/ui").Include("~/Content/css/icomoon.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/core.css",
                "~/Content/css/components.css",
                "~/Content/css/colors.css",
                "~/Content/css/bootbox.css",
                "~/Content/css/switch.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include("~/Content/kendo-ui/styles/kendo.common.min.css",
                "~/Content/kendo-ui/styles/kendo.silver.min.css",
                "~/Content/kendo-ui/styles/kendoCustom.css",
                "~/Content/kendo-ui/styles/kendo.custom.css",
                "~/Content/kendo-ui/styles/telerikReportViewer.css",
                "~/Content/css/pnotify.custom.min.css",
                "~/Content/ussal-notification/ussal-notification.css"));
            #endregion

            #region Scripts
            bundles.Add(new ScriptBundle("~/Scripts/HeaderJQuery").Include("~/Scripts/jquery.min.js",
                "~/Content/kendo-ui/js/kendo.all.min.js",
                "~/Content/kendo-ui/js/kendo.aspnetmvc.min.js",
                "~/Content/kendo-ui/js/telerikReportViewer-12.1.18.620.min.js",
                "~/Scripts/jszip.min.js",
                "~/Scripts/switchery.min.js",
                "~/Content/ussal-notification/ussal-notification.js",
                "~/Scripts/jquery.signalR-2.4.1.min.js"));

            var bundleJquery = new ScriptBundle("~/Scripts/JQueryScripts").Include("~/Scripts/jquery.min.js",
                     "~/Scripts/jquery.validate.min.js",
                     "~/Scripts/jquery.validate.unobtrusive.min.js");
            bundleJquery.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundleJquery);



            bundles.Add(new ScriptBundle("~/Scripts/LoginJQuery").Include("~/Scripts/bootstrap.min.js",
                    "~/Scripts/blockui.min.js",
                    "~/Scripts/nicescroll.min.js",
                    "~/Scripts/drilldown.js",
                    "~/Scripts/app.js",
                    "~/Scripts/uniform.min.js"
                   ));


            var bundle = new ScriptBundle("~/Scripts/UIScripts").Include("~/Scripts/bootstrap.min.js",
                    "~/Scripts/blockui.min.js",
                    "~/Scripts/nicescroll.min.js",
                    "~/Scripts/drilldown.js",
                    "~/Scripts/app.js",
                    "~/Scripts/bootbox.js",
                    "~/Content/kendo-ui/js/cultures/kendo.culture.en-IN.min.js",
                    "~/Scripts/Common.js",
                       "~/Scripts/uniform.min.js",
                        "~/Scripts/validate.min.js",
                        "~/Scripts/cookie.js",
                        "~/Scripts/app.js",
                        "~/Scripts/wizard_steps.js",
                        "~/Scripts/ripple.min.js",
                        "~/Scripts/pnotify.custom.min.js"
                    );
            bundle.Orderer = new AsIsBundleOrderer();


            bundles.Add(bundle);


            #endregion



            BundleTable.EnableOptimizations = false;
        }
        public class AsIsBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }

        }
    }
}
