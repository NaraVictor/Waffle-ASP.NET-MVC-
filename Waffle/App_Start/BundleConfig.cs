using System.Web;
using System.Web.Optimization;

namespace Waffle
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/dropzone.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/User").Include(
                      "~/Scripts/User/assets/js/core/bootstrap.min.js",
                      "~/Scripts/User/assets/js/core/jquery.min.js",
                      "~/Scripts/User/assets/js/core/popper.min.js",
                      "~/Scripts/User/assets/js/paper-dashboard.js",
                      "~/Scripts/User/assets/js/plugins/perfect-scrollbar.jquery.min.js",
                      "~/Scripts/User/assets/js/plugins/chartjs.min.js",
                      "~/Scripts/User/assets/js/plugins/bootstrap-notify.js",
                      "~/Scripts/User/assets/js/paper-dashboard.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/User").Include(
                "~/Content/User/css/bootstrap.min.css",
                "~/Content/User/css/paper-dashboard.css",
                "~/Content/User/css/user.css",
                "~/Content/font-awesome.css"
                ));
        }
    }
}
