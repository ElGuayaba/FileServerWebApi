using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Linq;

namespace FileServer.Application.Services.Workflow
{
	/// <summary>
	/// Class in charge of running a workflow associated with Clients
	/// </summary>
	public class CompanyClientWorkflow
	{
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public static bool Init()
		{
			try
			{
				var clients = HttpClientService.GetCall();
				var service = new CompanyClientService();
				foreach (CompanyClient client in clients)
				{
					service.Add(client);
				}
				return true;
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetCallError, ex);
			}
		}

		public static bool Refresh()
		{
			try
			{
				var clients = HttpClientService.GetCall();
				var service = new CompanyClientService();
				var stored = service.GetAll();
				bool hasChanged = !clients.SequenceEqual(stored);
				if (hasChanged)
				{
					LogManager.LogDebug();
					service.Clear();
					foreach (CompanyClient client in clients)
					{
						service.Add(client);
					} 
				}
				return true;
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetCallError, ex);
			}
		}
	}
}
