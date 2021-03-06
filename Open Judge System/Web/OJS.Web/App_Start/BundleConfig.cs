﻿namespace OJS.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                      "~/Scripts/global.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Dependencies/jquery/jquery.js",
                        "~/Dependencies/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Dependencies/jquery-validation/jquery.validate.js",
                        "~/Dependencies/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Dependencies/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/KendoUI/2014.3.1411/kendo.all.js",
                        "~/Scripts/KendoUI/2014.3.1411/kendo.aspnetmvc.js",
                        "~/Scripts/KendoUI/2014.3.1411/cultures/kendo.culture.bg.js",
                        "~/Scripts/KendoUI/2014.3.1411/cultures/kendo.culture.en-GB.js"));

            bundles.Add(new ScriptBundle("~/bundles/codemirror").Include(
                        "~/Dependencies/codemirror/lib/codemirror.js",
                        "~/Dependencies/codemirror/mode/clike/clike.js",
                        "~/Dependencies/codemirror/mode/javascript/javascript.js"));

            bundles.Add(new ScriptBundle("~/bundles/codemirrormerge").Include(
                        "~/Dependencies/codemirror/addon/merge/merge.js",
                        "~/Dependencies/diff_match_patch/lib/diff_match_patch.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/KendoUI/kendo").Include(
                      "~/Content/KendoUI/kendo.common.css",
                      "~/Content/KendoUI/kendo.blueopal.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/bootstrap").Include(
                      "~/Content/bootstrap/bootstrap-flatly.css"));

            bundles.Add(new StyleBundle("~/Content/CodeMirror/codemirror").Include(
                      "~/Dependencies/codemirror/lib/codemirror.css",
                      "~/Dependencies/codemirror/theme/tomorrow-night-eighties.css",
                      "~/Dependencies/codemirror/theme/the-matrix.css"));

            bundles.Add(new StyleBundle("~/Content/CodeMirror/codemirrormerge").Include(
                      "~/Dependencies/codemirror/addon/merge/merge.css",
                      "~/Content/Contests/submission-view-page.css"));

            bundles.Add(new StyleBundle("~/Content/Contests/submission-page").Include(
                      "~/Content/Contests/submission-page.css"));

            bundles.Add(new StyleBundle("~/Content/CodeMirror/codemirrormerge").Include(
                      "~/Dependencies/codemirror/addon/merge/merge.css",
                      "~/Content/Contests/submission-view-page.css"));
        }
    }
}
