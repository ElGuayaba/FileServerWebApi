using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.Contract
{
	/// <summary>
	/// Contract that specifies methods that don't modify the storage entity.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="FileServer.Application.Services.Contract.IServiceQueries{T}" />
	public interface IServiceOperations<T> : IServiceQueries<T>
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
