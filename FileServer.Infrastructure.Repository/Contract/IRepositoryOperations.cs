using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Contract
{
	/// <summary>
	/// Contract specifying methods that modify the storage entity.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="FileServer.Infrastructure.Repository.Contract.IRepositoryQueries{T}" />
	public interface IRepositoryOperations<T> : IRepositoryQueries<T>
	{
		/// <summary>
		/// Adds the specified model to the storage entity.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		T Add(T model);
		/// <summary>
		/// Updates the specified model to the storage entity.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		T Update(T model);
		/// <summary>
		/// Removes the specified identifier from the storage entity.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		bool Remove(int id);
	}
}
