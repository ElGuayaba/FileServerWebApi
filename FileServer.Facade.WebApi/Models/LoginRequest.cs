using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileServer.Facade.WebApi.Models
{
	public class LoginRequest
	{
		public Guid UserId { get; set; }
	}
}