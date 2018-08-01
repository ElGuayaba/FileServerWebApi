using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Linq;

namespace FileServer.Application.Service.Workflow
{
	/// <summary>
	/// Class in charge of running a workflow associated with Policies
	/// </summary>
	public class CompanyPolicyWorkflow
	{
		private static ICompanyPolicyService iService;

		public CompanyPolicyWorkflow(ICompanyPolicyService service)
		{
			iService = service;
		}

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
				foreach (CompanyPolicy policy in policies)
				{
					iService.Add(policy);
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
				var stored = iService.GetAll();
				bool hasChanged = !policies.SequenceEqual(stored);
				if (hasChanged)
				{
					LogManager.LogDebug();
					iService.Clear();
					foreach (CompanyPolicy policy in policies)
					{
						iService.Add(policy);
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
