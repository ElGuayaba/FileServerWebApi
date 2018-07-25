using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using FileServer.Facade.WebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace FileServer.Facade.WebApi.Controllers
{
	/// <summary>
	/// Token validator for Authorization Request using a DelegatingHandler
	/// </summary>
	internal class TokenValidationHandler : DelegatingHandler
	{
		public HttpResponseMessage RequestToken([FromBody] LoginRequest request)
		{
			var results = new List<ValidationResult>();
			var context = new ValidationContext(request, null, null);
			if (!Validator.TryValidateObject(request, context, results))
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
			var clientService = new CompanyClientService();
			var search = clientService.GetByID(request.UserId);

			if (search.Count == 0)
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}
			var client = search.First();
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
				new Claim(ClaimTypes.Role, client.Role)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				ConfigurationManager.AppSettings["JWT_SECRET_KEY"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"],
				audience: ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: creds);
			var response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StringContent(new JwtSecurityTokenHandler().WriteToken(token));

			return response;
		}

			//private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
			//{
			//	token = null;
			//	IEnumerable<string> authzHeaders;
			//	if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
			//	{
			//		return false;
			//	}
			//	var bearerToken = authzHeaders.ElementAt(0);
			//	token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
			//	return true;
			//}

			//protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			//{
			//	HttpStatusCode statusCode;
			//	string OutToken;

			//	// determine whether a jwt exists or not
			//	if (!TryRetrieveToken(request, out OutToken))
			//	{
			//		statusCode = HttpStatusCode.Unauthorized;
			//		return base.SendAsync(request, cancellationToken);
			//	}

			//	try
			//	{
			//		var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
			//		var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
			//		var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
			//		var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
			//		var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			//		var clientService = new CompanyClientService();
			//		//Validating the request
			//		var results = new List<ValidationResult>();
			//		var context = new ValidationContext(request, null, null);
			//		if (!Validator.TryValidateObject(request, context, results))
			//		{
			//			statusCode = HttpStatusCode.BadRequest;
			//		}
			//		var content = request.Content.ReadAsStringAsync().Result;
			//		var id = Json<Guid>.DeserializeObject(content).First();
			//		var getById = clientService.GetByID(id);
			//		if (getById.Count == 0)
			//		{
			//			statusCode = HttpStatusCode.NotFound;
			//		}
			//		CompanyClient client = getById.First();

			//		var claims = new[]
			//		{
			//			new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
			//			new Claim(ClaimTypes.Role, client.Role)
			//		};


			//		var token = new JwtSecurityToken(
			//		issuer: issuerToken,
			//		audience: audienceToken,
			//		claims: claims,
			//		expires: DateTime.Now.AddMinutes(120),
			//		signingCredentials: creds);



			//		SecurityToken securityToken;
			//		var tokenHandler = new JwtSecurityTokenHandler();
			//		TokenValidationParameters validationParameters = new TokenValidationParameters()
			//		{
			//			ValidAudience = audienceToken,
			//			ValidIssuer = issuerToken,
			//			ValidateLifetime = true,
			//			ValidateIssuerSigningKey = true,
			//			LifetimeValidator = this.LifetimeValidator,
			//			IssuerSigningKey = securityKey
			//		};

			//		// Extract and assign Current Principal and user
			//		Thread.CurrentPrincipal = tokenHandler.ValidateToken(OutToken, validationParameters, out securityToken);
			//		HttpContext.Current.User = tokenHandler.ValidateToken(OutToken, validationParameters, out securityToken);

			//		return base.SendAsync(request, cancellationToken);
			//	}
			//	catch (SecurityTokenValidationException)
			//	{
			//		statusCode = HttpStatusCode.Unauthorized;
			//	}
			//	catch (Exception)
			//	{
			//		statusCode = HttpStatusCode.InternalServerError;
			//	}

			//	return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
			//}

			//public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
			//{
			//	if (expires != null)
			//	{
			//		if (DateTime.UtcNow < expires) return true;
			//	}
			//	return false;
			//}
		}
	}