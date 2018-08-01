using Autofac;
using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
using FileServer.Application.Service.Workflow;
using FileServer.Application.Service.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileServer.Facade.WebApi.Module
{
	public class WebApiModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<CompanyClientService>()
				.As<ICompanyClientService>()
				.SingleInstance();

			builder
				.RegisterType<CompanyPolicyService>()
				.As<ICompanyPolicyService>()
				.SingleInstance();

			builder
				.RegisterType<AuthenticationService>()
				.As<IAuthenticate>()
				.SingleInstance();

			builder
				.RegisterType<CompanyClientWorkflow>()
				.As<IStartable>()
				.PropertiesAutowired();

			//builder
			//	.RegisterType<LogManager>()
			//	.As<ILogger>()
			//	.InstancePerRequest();

			builder.RegisterModule(new ServiceModule());

			base.Load(builder);
		}
	}
}