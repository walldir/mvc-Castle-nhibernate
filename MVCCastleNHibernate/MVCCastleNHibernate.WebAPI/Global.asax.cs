using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MVCCastleNHibernate.WebAPI.Infrastructure.Installer;

namespace MVCCastleNHibernate.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private WindsorContainer _container;
        protected void Application_Start()
        {
            InitializeWindsor();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            if (_container != null)
            {
                _container.Dispose();
            }
        }

        public void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            GlobalConfiguration.Configuration.DependencyResolver = new Infrastructure.Dependency.DependencyResolver(_container.Kernel);
        }
    }
}
