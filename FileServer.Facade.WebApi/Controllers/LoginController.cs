using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel;
using System.Threading;
using FileServer.Facade.WebApi.Models;
using FileServer.Application.Service.Service;
using FileServer.Application.Service.Contract;
using FileServer.Common.Entities;
using FileServer.Application.Services.Contract;
using FileServer.Application.Services.Service;
using FileServer.Common.Layer;

namespace FileServer.Facade.WebApi.Controllers
{
	/// <summary>
	/// Controller in charge of managing login operations.
	/// </summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	[AllowAnonymous]
	[RoutePrefix("api/login")]
	public class LoginController : ApiController
	{
		/// <summary>
		/// The authentication service
		/// </summary>
		IAuthenticate iService;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginController"/> class.
		/// </summary>
		public LoginController() : this(new AuthenticationService())
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginController" /> class.
		/// </summary>
		/// <param name="companyClientService">The company client service.</param>
		public LoginController(AuthenticationService companyClientService)
		{
			this.iService = companyClientService;
		}

		/// <summary>
		/// Sends a ping to the web service to check if it's online.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("echoping")]
		public IHttpActionResult EchoPing()
		{
			return Ok(true);
		}

		/// <summary>
		/// Authenticates the user based on its ID.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <returns>A token if successful, InternalServerError if not, 
		/// BadRequest in any other cases.
		/// </returns>
		[HttpPost]
		[Route("authenticate")]
		public IHttpActionResult Authenticate(LoginRequest login)
		{
			if (login == null)
				return BadRequest();
			try
			{
				CompanyClient user = iService.Authenticate(login.UserId);
				if (user != null)
				{
					var token = TokenGenerator.GenerateTokenJwt(user.Name, user.Email, user.Role);
					return Ok(token);
				}
				else
				{
					return Unauthorized();
				}
			}
			catch (VuelingException)
			{
				return InternalServerError();
			}
		}
	}
}
