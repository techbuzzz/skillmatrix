﻿using System.Web;
using System.Web.Optimization;

namespace SkillMatrix.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.slimscroll.js",
                "~/Scripts/jquery.fabric.js",
                "~/Scripts/vendor/PickaDate.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                "~/Scripts/app.js",
                "~/Scripts/pace.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/animate.css",
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/metisMenu.css",
                "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/of").Include(
                "~/Content/fabric.css", 
                "~/Content/fabric-9.6.0.scoped"));
        }
    }
}