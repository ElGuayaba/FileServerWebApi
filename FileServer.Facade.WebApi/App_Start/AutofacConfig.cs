using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FileServer.Facade.WebApi.Module;

namespace FileServer.Facade.WebApi.App_Start
{
	public class AutofacConfig
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new WebApiModule());

			var container = builder.Build();

			// El que resuelve todas las clases registradas -> AutofacWebApiDependencyResolver
			var resolver = new AutofacWebApiDependencyResolver(container);

			GlobalConfiguration.Configuration.DependencyResolver = resolver;

			return container;
		}
	}
}