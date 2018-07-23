using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;

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
				var policies = HttpClientController.GetCall();
				CompanyClientService service = new CompanyClientService();
				foreach (CompanyClient policy in policies)
				{
					service.Add(policy);
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
