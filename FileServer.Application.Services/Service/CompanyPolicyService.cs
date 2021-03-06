﻿using FileServer.Application.Service.Contract;
using FileServer.Common.Entities;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Repository;
using System.Collections.Generic;
using FileServer.Common.Layer;
using System;

namespace FileServer.Application.Service.Service
{
	public class CompanyPolicyService : ICompanyPolicyService
	{
		/// <summary>
		/// Generic repository.
		/// </summary>
		private readonly ICompanyPolicyRepository iRepository;

		//}
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyPolicyService"/> class.
		/// </summary>
		/// <param name="companyPolicyRepository">The companyPolicy repository.</param>
		public CompanyPolicyService(ICompanyPolicyRepository companyPolicyRepository)
		{
			this.iRepository = companyPolicyRepository;
		}
		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="companyPolicy">The companyPolicy.</param>
		/// <returns></returns>
		public CompanyPolicy Add(CompanyPolicy companyPolicy)
		{
			try
			{
				return iRepository.Add(companyPolicy);
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
		public List<CompanyPolicy> GetAll()
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
		public CompanyPolicy GetByID(Guid id)
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
		/// <param name="policyId">The identifier.</param>
		/// <returns></returns>
		public CompanyClient GetClient(Guid policyId)
		{
			try
			{
				return iRepository.GetClient(policyId);
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
		/// <returns>A boolean true if successful, false otherwise</returns>
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
		/// Updates the specified CompanyPolicy object in the database.
		/// </summary>
		/// <param name="companyPolicy">The companyPolicy object.</param>
		/// <returns>The CompanyPolicy object updated, null if unsuccessful</returns>
		public CompanyPolicy Update(CompanyPolicy companyPolicy)
		{
			try
			{
				return iRepository.Update(companyPolicy);
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.UpdateError, ex);
			}
		}
		/// <summary>
		/// Clears the storage entity.
		/// </summary>
		/// <exception cref="VuelingException"></exception>
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
