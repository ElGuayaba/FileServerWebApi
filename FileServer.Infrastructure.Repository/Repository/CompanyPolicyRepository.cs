using FileServer.Common.Entities;
using FileServer.Common.Layer;
using FileServer.Infrastructure.Repository.Contract;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Repository
{
	public class CompanyPolicyRepository : ICompanyPolicyRepository
	{
		private const string HashId = "Policies";
		IRedisClientsManager Manager;
		IRedisTypedClient<CompanyPolicy> redisClient;
		ICompanyClientRepository clientRepo;
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyPolicyRepository"/> class.
		/// </summary>
		public CompanyPolicyRepository(IRedisClientsManager redisClient, ICompanyClientRepository repo)
		{
			this.Manager = redisClient;
			this.redisClient = Manager.GetClient().As<CompanyPolicy>();
			this.clientRepo = repo;
		}

		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="companyPolicy">Alumno object to be added.</param>
		/// <returns>The object added if successful, null otherwise</returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyPolicy Add(CompanyPolicy companyPolicy)
		{
			try
			{
				var Hash = redisClient.GetHash<Guid>(HashId);
				redisClient.SetEntryInHashIfNotExists(Hash, companyPolicy.Id, companyPolicy);
				return redisClient.GetFromHash(companyPolicy.Id);
			}
			catch (Exception ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.DeleteError, ex);
			}
		}

		/// <summary>
		/// Gets all objects from sotrage file.
		/// </summary>
		/// <returns>
		/// The objects stored in a list.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public List<CompanyPolicy> GetAll()
		{
			try
			{
				var Hash = redisClient.GetHash<Guid>(HashId);
				return redisClient.GetHashValues(Hash);
			}
			catch (Exception ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Gets Alumno objects by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// The result from the query by ID.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyPolicy GetByID(Guid id)
		{
			try
			{
				if (Exists(id))
				{
					var Hash = redisClient.GetHash<Guid>(HashId);
					return redisClient.GetValueFromHash(Hash,id);
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Gets Alumno objects by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// The result from the query by ID.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient GetClient(Guid policyId)
		{
			try
			{
				var policies = GetAll();
				var result = policies.Where(pol => pol.Id.Equals(policyId)).ToList();
				CompanyPolicy policy = result.FirstOrDefault();
				if (policy != null)
				{
					return clientRepo.GetByID(policy.ClientId);
				}
				else
					return null;

			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}catch (ArgumentNullException ex)
			{
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Removes first object found with the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// A boolean indicating the result of the operation.
		/// true if successful, false otherwise.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public bool Remove(Guid id)
		{
			try
			{
				if (Exists(id))
				{
					var Hash = redisClient.GetHash<Guid>(HashId);
					redisClient.DeleteById(id);
					return true;
				}
				else
					return false;
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.DeleteError, ex);
			}
		}

		/// <summary>
		/// Updates the specified Alumno object.
		/// </summary>
		/// <param name="companyPolicy">The object to be inserted.</param>
		/// <returns>
		/// The inserted object.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyPolicy Update(CompanyPolicy companyPolicy)
		{
			try
			{
				if (Exists(companyPolicy.Id))
				{
					var Hash = redisClient.GetHash<Guid>(HashId);
					redisClient.SetEntryInHash(Hash, companyPolicy.Id, companyPolicy);
					return redisClient.GetFromHash(companyPolicy.Id);
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.UpdateError, ex);
			}
		}

		public bool Exists(Guid clientId)
		{
			var Hash = redisClient.GetHash<Guid>(HashId);
			return redisClient.HashContainsEntry(Hash, clientId);
		}

		public void Clear()
		{
			try
			{
				var Hash = redisClient.GetHash<Guid>(HashId);
				redisClient.DeleteAll();
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ClearError, ex);
			}
		}
	}
}
