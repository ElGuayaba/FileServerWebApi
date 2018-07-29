using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Contract
{
	public interface IAuthenticate
	{
		CompanyClient Authenticate(Guid login);
	}
}
