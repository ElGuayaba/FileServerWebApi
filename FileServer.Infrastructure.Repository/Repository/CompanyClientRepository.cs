using System;
using System.Collections.Generic;
using System.Linq;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace FileServer.Infrastructure.Repository.Repository
{
	/// <summary>
	/// Repository class for CompanyClient objects.
	/// </summary>
	/// <seealso cref="FileServer.Infrastructure.Repository.Contract.IRepositoryOperations{FileServer.Common.Entities.CompanyClient}" />
	public class CompanyClientRepository : ICompanyClientRepository
	{
		private const string HashId = "Clients";
		IRedisClientsManager Manager;
		IRedisTypedClient<CompanyClient> redisClient;
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyClientRepository"/> class.
		/// </summary>
		public CompanyClientRepository(RedisManagerPool redisClient)
		{
			Manager = redisClient;
			this.redisClient = Manager.GetClient().As<CompanyClient>();
		}

		public CompanyClientRepository() : this(new RedisManagerPool(Properties.Settings.Default.ConnectionAddress))
		{
		}

		/// <summary>
		/// Adds the specified CompanyClient object.
		/// </summary>
		/// <param name="companyClient">CompanyClient object to be added.</param>
		/// <returns>The object added if successful, null otherwise</returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Add(CompanyClient companyClient)
		{
			try
			{
				var Hash = redisClient.GetHash<Guid>(HashId);
				redisClient.SetEntryInHashIfNotExists(Hash, companyClient.Id, companyClient);
				return redisClient.GetFromHash(companyClient.Id);
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
		public List<CompanyClient> GetAll()
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
		public CompanyClient GetByID(Guid id)
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
		/// <param name="name">The identifier.</param>
		/// <returns>
		/// The result from the query by ID.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public List<CompanyClient> GetByName(string name)
		{
			try
			{
				var clients = GetAll();
				return clients.Where(alu => alu.Name.Equals(name)).ToList();
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.GetError, ex);
			}
			catch (ArgumentNullException ex)
			{
				LogManager.LogError();
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
		/// <param name="companyClient">The object to be inserted.</param>
		/// <returns>
		/// The inserted object.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Update(CompanyClient companyClient)
		{
			try
			{
				if (Exists(companyClient.Id))
				{
					var Hash = redisClient.GetHash<Guid>(HashId);
					redisClient.SetEntryInHash(Hash, companyClient.Id, companyClient);
					return redisClient.GetFromHash(companyClient.Id);
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
			catch (Exception ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ClearError, ex);
			}
		}
	}
}
