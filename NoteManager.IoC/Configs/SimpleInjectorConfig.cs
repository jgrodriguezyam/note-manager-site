using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace NoteManager.IoC.Configs
{
    public static class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            SimpleInjectorModule.SetContainer(container);
            SimpleInjectorModule.LoadServices();
            SimpleInjectorModule.VerifyContainer();
            SimpleInjectorModule.SetFilters();
            SimpleInjectorModule.LoadFilters();
        }
    }
}