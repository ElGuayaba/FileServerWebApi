using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	public interface IRepositoryQueries<T>
	{
		List<T> GetAll();
		List<T> GetByID(int id);
	}
}
