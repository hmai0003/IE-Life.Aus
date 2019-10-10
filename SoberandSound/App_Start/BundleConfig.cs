using System.Web;
using System.Web.Optimization;

namespace SoberandSound
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/cardgame").Include(
                       "~/Scripts/game.js"));

            bundles.Add(new ScriptBundle("~/bundles/gamescripts").Include(
           "~/Scripts/gamescripts.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery-3.4.1.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/flip-card.css"));

            bundles.Add(new StyleBundle("~/bundles/highchart").Include(
                      "~/High-chart/highcharts.js",
                      "~/High-chart/highcharts-more.js",
                      "~/High-chart/modules/exporting.js",
                      "~/High-chart/modules/export-data.js",
                      "~/High-chart/themes/grid-light.js"));

            bundles.Add(new StyleBundle("~/Content/gamecss").Include(
                      "~/Content/game.css"));

            bundles.Add(new StyleBundle("~/Content/gamestyles").Include(
                       "~/Content/gamestyles.css"));

        }
    }
}
