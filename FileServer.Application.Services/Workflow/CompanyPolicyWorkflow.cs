using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Linq;

namespace FileServer.Application.Services.Workflow
{
	/// <summary>
	/// Class in charge of running a workflow associated with Policies
	/// </summary>
	public class CompanyPolicyWorkflow
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
				var policies = HttpPolicyService.GetCall();
				CompanyPolicyService service = new CompanyPolicyService();
				foreach (CompanyPolicy policy in policies)
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

		public static bool Refresh()
		{
			try
			{
				var policies = HttpPolicyService.GetCall();
				var service = new CompanyPolicyService();
				var stored = service.GetAll();
				bool hasChanged = !policies.SequenceEqual(stored);
				if (hasChanged)
				{
					LogManager.LogDebug();
					service.Clear();
					foreach (CompanyPolicy policy in policies)
					{
						service.Add(policy);
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
