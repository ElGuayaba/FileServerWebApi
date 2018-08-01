using Autofac;
using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Linq;

namespace FileServer.Application.Service.Workflow
{
	/// <summary>
	/// Class in charge of running a workflow associated with Clients
	/// </summary>
	public class CompanyClientWorkflow : IWorkflow, IStartable
	{
		ICompanyClientService iService;
		public CompanyClientWorkflow(ICompanyClientService service)
		{
			iService = service;
		}
		//public CompanyClientWorkflow()
		//{
		//}
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public void Start()
		{
			try
			{
				var clients = HttpClientService.GetCall();
				foreach (CompanyClient client in clients)
				{
					iService.Add(client);
				}
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetCallError, ex);
			}
		}

		public void Refresh()
		{
			try
			{
				var clients = HttpClientService.GetCall();
				var stored = iService.GetAll();
				bool hasChanged = !clients.SequenceEqual(stored);
				if (hasChanged)
				{
					LogManager.LogDebug();
					iService.Clear();
					foreach (CompanyClient client in clients)
					{
						iService.Add(client);
					} 
				}
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetCallError, ex);
			}
		}
	}
}
