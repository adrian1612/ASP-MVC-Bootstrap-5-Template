using System.Web;
using System.Web.Optimization;

namespace ASP_MVC_Bootstrap_5_Template_v2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/jquery.mask.js",
                      "~/Scripts/echarts/echarts.js",
                      "~/Scripts/select2.js",
                      "~/Scripts/DataTables/dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap5.js",
                      "~/Scripts/DataTables/dataTables.buttons.js",
                      "~/Scripts/DataTables/buttons.bootstrap5.js",
                      "~/Scripts/DataTables/jszip.js",
                      "~/Scripts/DataTables/pdfmake.js",
                      "~/Scripts/DataTables/vfs_fonts.js",
                      "~/Scripts/DataTables/buttons.html5.js",
                      "~/Scripts/DataTables/buttons.print.js",
                      "~/Scripts/DataTables/buttons.colVis.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/tinymce/tinymce.js",
                      "~/Scripts/fontawesome/all.js",
                      "~/Scripts/index.global.js",
                      "~/Scripts/main.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/jquery.signaturepad.js",
                      "~/Content/SignaturePad/json2.min.js",
                      "~/Scripts/Angular/angular.js",
                      "~/Scripts/Angular/angular-route.js",
                      "~/Scripts/Angular/angular-animate.js",
                      "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/select2.css",
                      "~/Content/css/select2-bootstrap-5-theme.min.css",
                      "~/Content/DataTables/css/dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap5.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/DataTables/css/buttons.bootstrap5.css",
                      "~/Content/all.css",
                      "~/Content/toastr.css",
                      "~/Content/SignaturePad/jquery.signaturepad.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/variables.css",
                      "~/Content/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/Style.css",
                      "~/Content/site.css"));
        }
    }
}
