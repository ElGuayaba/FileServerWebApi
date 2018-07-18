using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Contract
{
	public interface IServiceQueries<T>
	{
		List<T> GetAll();
		List<T> GetByID(int id);
	}
}
