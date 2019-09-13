﻿using System.Web;
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery-3.4.1.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/flip-card.css",
                      "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/highchart").Include(
                      "~/High-chart/highcharts.js",
                      "~/High-chart/highcharts-more.js",
                      "~/High-chart/modules/exporting.js",
                      "~/High-chart/modules/export-data.js"));
        }
    }
}
