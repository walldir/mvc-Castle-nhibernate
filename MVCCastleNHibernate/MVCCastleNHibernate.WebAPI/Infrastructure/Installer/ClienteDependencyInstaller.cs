using System.Configuration;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCCastleNHibernate.Core.Services.Impl;
using MVCCastleNHibernate.Data.NHibernate;
using MVCCastleNHibernate.Data.NHibernate.Mappings;
using MVCCastleNHibernate.WebAPI.Infrastructure.Dependency;
using NHibernate;

namespace MVCCastleNHibernate.WebAPI.Infrastructure.Installer
{
    public class ClienteDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            container.Register(

                //Nhibernate session factory
                Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton,

                //Unitofwork interceptor
                Component.For<NhUnitOfWorkInterceptor>().LifeStyle.Transient,

                Classes.FromAssembly(Assembly.GetAssembly(typeof(NhClienteRepository))).InSameNamespaceAs<NhClienteRepository>().WithService.DefaultInterfaces().LifestyleTransient(),

                Classes.FromAssembly(Assembly.GetAssembly(typeof(ClienteService))).InSameNamespaceAs<ClienteService>().WithService.DefaultInterfaces().LifestyleTransient()

                );
        }

        private static ISessionFactory CreateNhSessionFactory()
        {
            var connStr = ConfigurationManager.ConnectionStrings["ClienteDB"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(ClienteMap))))
                .BuildSessionFactory();
        }

        void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
            }

            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                    return;
                }
            }
        }
    }
}