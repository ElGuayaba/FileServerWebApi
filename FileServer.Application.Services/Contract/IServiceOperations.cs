using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Contract
{
	public interface IServiceOperations<T> : IServiceQueries<T>
	{
		T Add(T model);
		T Update(T model);
		bool Remove(int id);
	}
}
