using FileServer.Application.Service.Contract;
using FileServer.Common.Entities;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Repository;
using System.Collections.Generic;
using FileServer.Common.Layer;
using System;

namespace FileServer.Application.Service.Service
{
	/// <summary>
	/// Service class for Alumno objects.
	/// </summary>
	/// <seealso cref="FileServer.Application.Service.Contract.IServiceOperations{FileServer.Common.Entities.CompanyClient}" />
	public class CompanyClientService : ICompanyClientService
	{
		/// <summary>
		/// Generic repository.
		/// </summary>
		private readonly ICompanyClientRepository iRepository;

		//}
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyClientService"/> class.
		/// </summary>
		/// <param name="companyClientRepository">The companyClient repository.</param>
		public CompanyClientService(ICompanyClientRepository companyClientRepository)
		{
			this.iRepository = companyClientRepository;
		}
		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="companyClient">The companyClient.</param>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Add(CompanyClient companyClient)
		{
			try
			{
				return iRepository.Add(companyClient);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.AddError, ex);
			}
		}

		/// <summary>
		/// Gets all objects from the storage entity.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public List<CompanyClient> GetAll()
		{
			try
			{
				return iRepository.GetAll();
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Gets objects from the storage entity by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient GetByID(Guid id)
		{
			try
			{
				return iRepository.GetByID(id);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
		}
		/// <summary>
		/// Gets objects from the storage entity by identifier.
		/// </summary>
		/// <param name="name">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public List<CompanyClient> GetByName(string name)
		{
			try
			{
				return iRepository.GetByName(name);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Removes the specified identifier from the storage entity.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public bool Remove(Guid id)
		{
			try
			{
				return iRepository.Remove(id);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.DeleteError, ex);
			}
		}

		/// <summary>
		/// Updates the specified companyClient.
		/// </summary>
		/// <param name="companyClient">The companyClient.</param>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Update(CompanyClient companyClient)
		{
			try
			{
				return iRepository.Update(companyClient);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.UpdateError, ex);
			}
		}

		public void Clear()
		{
			try
			{
				iRepository.Clear();
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ClearError, ex);
			}
		}
	}
}
