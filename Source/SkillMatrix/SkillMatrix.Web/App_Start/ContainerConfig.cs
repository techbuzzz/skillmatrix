using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using SkillMatrix.Data.Configurations.Identity;
using SkillMatrix.Data.Contexts;
using SkillMatrix.Infrastructure;
using SkillMatrix.Infrastructure.Interfaces;
using SkillMatrix.Repository;
using SkillMatrix.Service;

namespace SkillMatrix.Web
{
    public class ContainerConfig
    {
	    public static IContainer Container;

		public static void ConfigureContainer(IAppBuilder app)
	    {
		    var container = CreateContainer();
	        Container = container;
            app.UseAutofacMiddleware(container);
	        app.UseAutofacMvc();

        }

	    private static IContainer CreateContainer()
	    {
		    var builder = new ContainerBuilder();
		    var assembly = Assembly.GetExecutingAssembly();
		    builder.RegisterType<SkillMatrixServiceLocator>().As<IServiceLocator>().SingleInstance();

		    builder.RegisterType<DbFactory<SKMContext>>().As<IDbFactory<SKMContext>>().InstancePerLifetimeScope();
		    builder.RegisterType<UnitOfWork<SKMContext>>().As<IUnitOfWork>().SingleInstance();

		    builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<AccountManager>())
			    .As<AccountManager>();
		    builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();

		    builder.RegisterAssemblyTypes(typeof(SkillRepository).Assembly)
			    .Where(t => t.Name.EndsWith("Repository"))
			    .AsImplementedInterfaces()
			    .InstancePerLifetimeScope();
		    //// Services
		    builder.RegisterAssemblyTypes(typeof(SkillService).Assembly)
			    .Where(t => t.Name.EndsWith("Service"))
			    .AsImplementedInterfaces()
			    .InstancePerLifetimeScope();

	        var container = builder.Build();
	        var resolver = new AutofacWebApiDependencyResolver(container);
	        GlobalConfiguration.Configuration.DependencyResolver = resolver;

	        SetMvcDependencyResolver(container);
	        return container;
        }

        private static void RegisterMvc(ContainerBuilder builder, Assembly assembly)
        {
            // Register Common MVC Types
            builder.RegisterModule<AutofacWebTypesModule>();

            // Register MVC Filters
            builder.RegisterFilterProvider();

            // Register MVC Controllers
            builder.RegisterControllers(assembly);

            builder.RegisterApiControllers(assembly);
        }

        private static void SetMvcDependencyResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}