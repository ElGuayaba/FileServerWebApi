using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	public interface ICompanyClientRepository : IRepositoryOperations<CompanyClient>
	{
		List<CompanyClient> GetByName(string name);
	}
}
