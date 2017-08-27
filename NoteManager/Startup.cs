﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using NoteManager.IoC.Configs;
using NoteManager.Mapper;

[assembly: OwinStartup(typeof(NoteManager.Startup))]
namespace NoteManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorConfig.Register();
            FastMapperConfig.Initialize();
        }
    }
}
