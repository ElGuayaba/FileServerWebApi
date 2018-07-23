using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FileServer.Common.Layer.Resources;
using Serilog;

namespace FileServer.Common.Layer
{
	public static class LogManager
	{
		public static void LogDebug()
		{
			using (var Logger = new LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.File(@Properties.Settings.Default.DebugFilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".Trace.json", outputTemplate:
						"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}")
						.CreateLogger() )
			{
				Logger.Debug(new StackTrace().GetFrame(1).GetMethod().Name);
			}
		}

		public static void LogInfo()
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@Properties.Settings.Default.InfoFilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".InfoLog.json", outputTemplate:
						"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}")
						.CreateLogger())
			{
				Logger.Information(new StackTrace().GetFrame(1).GetMethod().Name);
			}
		}

		public static void LogError()
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@Properties.Settings.Default.ErrorFilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".ErrorLog.json", outputTemplate:
						"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}")
						.CreateLogger())
			{
				Logger.Error(new StackTrace().GetFrame(1).GetMethod().Name);
			}
		}

	}
}
