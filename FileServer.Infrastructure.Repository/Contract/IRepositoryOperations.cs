using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	public interface IRepositoryOperations<T>
	{
		T Add(T model);
		T Update(T model);
		int Remove(int id);
	}
}
