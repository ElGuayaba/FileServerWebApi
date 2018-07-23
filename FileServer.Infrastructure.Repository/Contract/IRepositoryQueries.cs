using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	/// <summary>
	/// Contract that specifies methods that don't modify the storage entity.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepositoryQueries<T>
	{
		/// <summary>
		/// Gets all objects from the storage entity.
		/// </summary>
		/// <returns></returns>
		List<T> GetAll();
		/// <summary>
		/// Gets objects from the storage entity by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		List<T> GetByID(Guid id);
	}
}
