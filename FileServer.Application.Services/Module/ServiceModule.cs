using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Module;
using FileServer.Infrastructure.Repository.Repository;

namespace FileServer.Application.Service.Module
{
	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<CompanyClientRepository>()
				.As<ICompanyClientRepository>()
				.SingleInstance();

			builder
				.RegisterType<CompanyPolicyRepository>()
				.As<ICompanyPolicyRepository>()
				.SingleInstance();

			builder
				.RegisterType<CompanyClientService>()
				.As<ICompanyClientService>()
				.SingleInstance();

			builder
				.RegisterType<CompanyPolicyService>()
				.As<ICompanyPolicyService>()
				.SingleInstance();


			//builder
			//	.RegisterType<LogManager>()
			//	.As<ILogger>()
			//	.InstancePerRequest();

			builder.RegisterModule(new RepositoryModule());

			base.Load(builder);
		}
	}
}
