using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System;
using System.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Application.Service;

namespace FileServer.Application.Service.Service
{
	public class AuthenticationService : IAuthenticate
	{
		ICompanyClientService iService;

		/// <summary>
		/// Initializes a new instance of the <see cref="AuthenticationService"/> class.
		/// </summary>
		/// <param name="companyClientService">The company client service.</param>
		public AuthenticationService(ICompanyClientService companyClientService)
		{
			this.iService = companyClientService;
		}

		public CompanyClient Authenticate(Guid login)
		{
			try
			{
				CompanyClient user = iService.GetByID(login);
				if (user.Equals(null))
					return null;
				bool isCredentialValid = (user.Role.Equals("admin") || user.Role.Equals("user"));
				if (isCredentialValid)
					return user;
				else
					return null;
			}
			catch (VuelingException ex)
			{

				throw new VuelingException(Resources.GetError, ex);
			}			
		}
	}
}
