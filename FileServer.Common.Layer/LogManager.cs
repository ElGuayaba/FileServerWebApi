using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FileServer.Common.Layer.Resources;
using Serilog;

namespace FileServer.Common.Layer
{
	public static class LogManager
	{
		public static void LogDebug(string message)
		{
			using (var Logger = new LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.File(@LogResources.FilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".Trace.json")
						.CreateLogger() )
			{
				Logger.Debug(message);
			}
		}

		public static void LogInfo(string message)
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@LogResources.FilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".InfoLog.json")
						.CreateLogger())
			{
				Logger.Information(message);
			}
		}

		public static void LogError(string message)
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@LogResources.FilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".ErrorLog.json")
						.CreateLogger())
			{
				Logger.Information(message);
			}
		}

		public static void LogWarning(string message)
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@LogResources.FilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".WarningLog.json")
						.CreateLogger())
			{
				Logger.Information(message);
			}
		}

		public static void LogFatal(string message)
		{
			using (var Logger = new LoggerConfiguration()
						.WriteTo.File(@LogResources.FilePath
						+ Assembly.GetCallingAssembly().GetName().Name + ".FatalLog.json")
						.CreateLogger())
			{
				Logger.Information(message);
			}
		}
	}
}
