using System.Web.Optimization;
using NoteManager.Content.Bundles;

namespace NoteManager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundleModule.RegisterBundles(bundles);
            StyleBundleModule.RegisterBundles(bundles);
            BundleTable.EnableOptimizations = false;
        }
    }
}
