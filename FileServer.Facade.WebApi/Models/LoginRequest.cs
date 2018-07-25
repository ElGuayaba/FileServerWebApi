using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileServer.Facade.WebApi.Models
{
	public class LoginRequest
	{
		[Required]
		public Guid UserId { get; set; }
	}
}