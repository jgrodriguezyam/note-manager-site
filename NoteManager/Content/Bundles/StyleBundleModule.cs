using System.Web.Optimization;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Content.Bundles
{
    public class StyleBundleModule
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(string.Format(WebConstants.RootBundleStyles, "Shared", "Master"))
                .Include("~/Content/Components/Bootstrap/Css/Bootstrap-fonts.min.css", new CssRewriteUrlTransform())
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap.min.css",
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css",
                    "~/Content/Components/Messenger/Css/Messenger.min.css",
                    "~/Content/Components/DateRAngePicker/Css/daterangepicker.css",
                    "~/Content/Components/JQuery/Css/JQuery-ui.css",
                    "~/Content/Components/MetisMenu/metisMenu.min.css",
                    "~/Content/Components/Admin/css/sb-admin-2.css",
                    "~/Content/Components/FontAwesome/css/font-awesome.min.css",
                    "~/Content/Css/General.css"));

            bundles.Add(new StyleBundle(string.Format(WebConstants.RootBundleStyles, EController.Home, EAction.Index))
                .Include("~/Content/Css/Home/Index.css", new CssRewriteUrlTransform()));
        }
    }
}