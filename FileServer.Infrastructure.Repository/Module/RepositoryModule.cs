using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Repository;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace FileServer.Infrastructure.Repository.Module
{
	public class RepositoryModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			
			builder
				.RegisterType<RedisManagerPool> ()
				.As<IRedisClientsManager>()
				.WithParameter("host", Properties.Settings.Default.ConnectionAddress)
				.UsingConstructor(typeof(string))
				.SingleInstance();

			builder
				.RegisterType<CompanyClientRepository>()
				.As<ICompanyClientRepository>()
				.SingleInstance();


			//builder
			//	.RegisterType<LogManager>()
			//	.As<ILogger>()
			//	.InstancePerRequest();

			base.Load(builder);
		}
	}
}
