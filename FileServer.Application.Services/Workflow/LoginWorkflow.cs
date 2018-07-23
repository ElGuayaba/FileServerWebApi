using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Workflow
{
	public class LoginWorkflow
	{
		public static CompanyClient Init(Guid id)
		{
			CompanyClientService authService = new CompanyClientService();
			List<CompanyClient> result = authService.GetByID(id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}
	}
}
