using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Service.Scheduler
{
	public class Scheduler
	{
		public static async void Start()

		{
			StdSchedulerFactory sf = new StdSchedulerFactory();

			IScheduler scheduler = await sf.GetScheduler();
			await scheduler.Start();
			IJobDetail job = JobBuilder.Create<ScheduleRefresh>().Build();
			ITrigger trigger = TriggerBuilder.Create()
			 .WithIdentity("Refresh")
			 .StartAt(DateTimeOffset.Now.AddSeconds(50))
			 .WithSimpleSchedule(x => x
			   .WithIntervalInHours(1)
			   .RepeatForever())
			   .Build();

			await scheduler.ScheduleJob(job, trigger);

		}
	}
}
