using System.Reflection;
using System.Web.Mvc;
using NoteManager.Infrastructure.Attributes;
using NoteManager.Services.Implements;
using NoteManager.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace NoteManager.IoC.Configs
{
    public static class SimpleInjectorModule
    {
        private static Container _container;
        private static GlobalFilterCollection _filters;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static Container GetContainer()
        {
            return _container;
        }

        public static void LoadServices()
        {
            _container.Register<IUserService, UserService>();
            _container.Register<ICustomerService, CustomerService>();
            _container.Register<ICompanyService, CompanyService>();
        }

        public static void VerifyContainer()
        {
            _container.RegisterMvcIntegratedFilterProvider();
            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }

        public static void SetFilters()
        {
            _filters = GlobalFilters.Filters;
        }

        public static void LoadFilters()
        {
            _filters.Add(_container.GetInstance<ExceptionAttribute>());
        }
    }
}