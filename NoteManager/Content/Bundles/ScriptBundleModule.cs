using System.Web.Optimization;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Content.Bundles
{
    public class ScriptBundleModule
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Master

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, "Shared", "Master"))
                .Include(
                    "~/Content/Components/JQuery/Scripts/JQuery.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-autohidingnavbar.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-filestyle.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Messenger/Scripts/Messenger.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Components/PopupOverlay/Scripts/PopupOverlay.min.js",
                    "~/Content/Components/SlimScroll/Scripts/SlimScroll.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-customradio.min.js",
                    "~/Content/Components/MetisMenu/metisMenu.min.js",
                    "~/Content/Components/Admin/js/sb-admin-2.js",
                    "~/Content/Scripts/General.js",
                    "~/Content/Scripts/ResourcesJavaScript.js"));

            #endregion

            #region Home

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Home, EAction.Index))
                .Include(
                    "~/Content/Scripts/Home/Index.js"));

            #endregion

            #region Customer

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Customer, EAction.Index))
                .Include(
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Customer/Index.js"));

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Customer, EAction.New))
                .Include(
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/additional-methods.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.unobtrusive.min.js",
                    "~/Content/Scripts/Customer/Form.js",
                    "~/Content/Scripts/Customer/New.js"));

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Customer, EAction.Edit))
                .Include(
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/additional-methods.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.unobtrusive.min.js",
                    "~/Content/Scripts/Customer/Form.js",
                    "~/Content/Scripts/Customer/Edit.js"));

            #endregion

            #region Company

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Company, EAction.Index))
                .Include(
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Company/Index.js"));

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Company, EAction.New))
                .Include(
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/additional-methods.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.unobtrusive.min.js",
                    "~/Content/Scripts/Company/Form.js",
                    "~/Content/Scripts/Company/New.js"));

            bundles.Add(new ScriptBundle(string.Format(WebConstants.RootBundleScripts, EController.Company, EAction.Edit))
                .Include(
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/additional-methods.min.js",
                    "~/Content/Components/JQueryValidation/Scripts/jquery.validate.unobtrusive.min.js",
                    "~/Content/Scripts/Company/Form.js",
                    "~/Content/Scripts/Company/Edit.js"));

            #endregion
        }
    }
}