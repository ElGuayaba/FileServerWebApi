using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Text;
using System.Net;

namespace FileServer.Application.Services
{
	/// <summary>
	/// Controller in charge of getting information from a webapi
	/// </summary>
	public class HttpPolicyController
	{
		/// <summary>
		/// The client
		/// </summary>
		static WebClient client;
		/// <summary>
		/// Initializes the <see cref="HttpPolicyController"/> class.
		/// </summary>
		static HttpPolicyController()
		{
			client = new WebClient();
		}

		/// <summary>
		/// Gets the call.
		/// </summary>
		/// <returns></returns>
		public static CompanyPolicy[] GetCall()
		{
			ArrayEntity<CompanyPolicy> listPolicies;
			try
			{
				String policyJsonString = client.DownloadString(Properties.Settings.Default.PolicyRoute);
				listPolicies = Json<ArrayEntity<CompanyPolicy>>.DeserializeObjectArray(policyJsonString);

				return listPolicies.policies;
			}
			catch (ArgumentNullException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ArgumentNull, ex);
			}
			catch (WebException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.WebError, ex);
			}
			catch (NotSupportedException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.NotSupported, ex);
			}
		}
	}
}
