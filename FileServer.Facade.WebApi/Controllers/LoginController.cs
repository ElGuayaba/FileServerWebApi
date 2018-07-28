using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel;
using System.Threading;
using FileServer.Facade.WebApi.Models;
using FileServer.Application.Services.Service;
using FileServer.Application.Services.Contract;
using FileServer.Common.Entities;

namespace FileServer.Facade.WebApi.Controllers
{    
	[AllowAnonymous]
	[RoutePrefix("api/login")]
	public class LoginController : ApiController
	{
		IServiceOperations<CompanyClient> iService = new CompanyClientService();

		public LoginController() : this(new CompanyClientService())
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientsController"/> class.
		/// </summary>
		/// <param name="companyClientService">The company client service.</param>
		public LoginController(CompanyClientService companyClientService)
		{
			this.iService = companyClientService;
		}

		[HttpGet]
		[Route("echoping")]
		public IHttpActionResult EchoPing()
		{
			return Ok(true);
		}

		[HttpGet]
		[Route("echouser")]
		public IHttpActionResult EchoUser()
		{
			var identity = Thread.CurrentPrincipal.Identity;
			return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
		}

		[HttpPost]
		[Route("authenticate")]
		public IHttpActionResult Authenticate(LoginRequest login)
		{
			if (login == null)
				return BadRequest();

			//Llamar al servicio de autenticación
			//vvv---meter toda esta lógica allí---vvv
			CompanyClient user = iService.GetByID(login.UserId).FirstOrDefault();
			if (user == null)
				return BadRequest();
			
			bool isCredentialValid = (user.Role.Equals("admin") || user.Role.Equals("user"));
			if (isCredentialValid)
			{
				var token = TokenGenerator.GenerateTokenJwt(user.Name, user.Email, user.Role);
				return Ok(token);
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
