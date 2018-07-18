using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Contract
{
	public interface IServiceOperations<T>
	{
		T Add(T model);
		T Update(T model);
		int Remove(int id);
	}
}
