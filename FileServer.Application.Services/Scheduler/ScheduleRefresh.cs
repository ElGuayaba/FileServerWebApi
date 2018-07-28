using FileServer.Application.Service.Workflow;
using FileServer.Common.Layer;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Service.Scheduler
{
	public class ScheduleRefresh : IJob
	{
		public void Refresh()
		{
			CompanyClientWorkflow.Refresh();
			CompanyPolicyWorkflow.Refresh();
		}
		public Task Execute(IJobExecutionContext context)
		{

			LogManager.LogDebug();
			Task task = new Task(new Action(() => Refresh()));
			task.Start();
			return task;
		}
	}
}
