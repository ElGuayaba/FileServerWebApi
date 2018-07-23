using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;

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
				var policies = HttpPolicyController.GetCall();
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
	}
}
