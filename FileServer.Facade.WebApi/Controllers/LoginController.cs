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
using FileServer.Common.Entities;

namespace FileServer.Facade.WebApi.Controllers
{
    
	[AllowAnonymous]
	[RoutePrefix("api/login")]
	public class LoginController : ApiController
	{
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
			CompanyClientService authService = new CompanyClientService();
			List<CompanyClient> result = authService.GetByID(login.UserId);
			CompanyClient companyClient;
			if (result != null)
				companyClient = result.First();
			else
				return BadRequest();
			
			bool isCredentialValid = (companyClient.Role.Equals("admin"));
			if (isCredentialValid)
			{
				var token = TokenGenerator.GenerateTokenJwt(companyClient.Name);
				return Ok(token);
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
