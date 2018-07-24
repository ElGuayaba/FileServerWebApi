using FileServer.Application.Services.Workflow;
using FileServer.Common.Layer;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Scheduler.Jobs
{
	public class GetClients : IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			LogManager.LogDebug();
			Task task = new Task(new Action(() => CompanyClientWorkflow.Refresh()));
			task.Start();
			return task;
		}
	}
}
