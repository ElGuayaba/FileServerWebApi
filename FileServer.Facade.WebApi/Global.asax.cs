﻿using FileServer.Application.Service.Workflow;
using FileServer.Application.Service.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FileServer.Facade.WebApi.App_Start;

namespace FileServer.Facade.WebApi
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AutofacConfig.Configure();
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			//CompanyClientWorkflow clientWorkflow = new CompanyClientWorkflow();
			//clientWorkflow.Init();
			//CompanyPolicyWorkflow.Init();
			//Scheduler.Start();
		}
	}
}
