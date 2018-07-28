using FileServer.Application.Service.Contract;
using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Service.Contract
{
	public interface ICompanyPolicyService : IServiceOperations<CompanyPolicy>
	{
		CompanyClient GetClient(Guid policyId);
	}
}
