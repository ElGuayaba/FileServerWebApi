using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	public interface ICompanyPolicyRepository : IRepositoryOperations<CompanyPolicy>
	{
		CompanyClient GetClient(Guid name);
	}
}
