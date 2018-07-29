using FileServer.Common.Entities;
using FileServer.Common.Layer;
using FileServer.Infrastructure.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repository.Repository
{
	public class CompanyPolicyRepository : ICompanyPolicyRepository
	{
		/// <summary>
		/// The filemanager
		/// </summary>
		private FileManager fm;
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyPolicyRepository"/> class.
		/// </summary>
		public CompanyPolicyRepository()
		{
			fm = new FileManager(Properties.Settings.Default.PolicyFile);
			fm.CreateFile();
		}

		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="companyPolicy">Alumno object to be added.</param>
		/// <returns>The object added if successful, null otherwise</returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyPolicy Add(CompanyPolicy companyPolicy)
		{
			List<CompanyPolicy> jsonNodes;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyPolicy>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyPolicy>();
				}
				jsonNodes.Add(companyPolicy);

				var resultJSONList = Json<CompanyPolicy>.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);
				return Json<CompanyPolicy>.DeserializeObject(fm.RetrieveData()).Last();
			}
			catch (VuelingException ex)
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
				var data = fm.RetrieveData();
				return Json<CompanyPolicy>.DeserializeObject(data);
			}
			catch (VuelingException ex)
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
		public List<CompanyPolicy> GetByID(Guid id)
		{
			try
			{
				var data = fm.RetrieveData();
				return Json<CompanyPolicy>.DeserializeObject(data).Where(alu => alu.Id.Equals(id)).ToList();
			}
			catch (VuelingException ex)
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
				CompanyClientRepository repo = new CompanyClientRepository();
				CompanyPolicy policy;
				CompanyClient client;
				var data = fm.RetrieveData();
				policy = Json<CompanyPolicy>.DeserializeObject(data).Where(pol => pol.Id.Equals(policyId))
					.ToList().FirstOrDefault();
				client = repo.GetByID(policy.ClientId).FirstOrDefault();

				return client;
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
			List<CompanyPolicy> jsonNodes;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyPolicy>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyPolicy>();
				}
				CompanyPolicy companyPolicy = jsonNodes.Where<CompanyPolicy>(alu => alu.Id.Equals(id)).First();
				jsonNodes.Remove(companyPolicy);

				var resultJSONList = Json<CompanyPolicy>.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);
				return true;
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
			List<CompanyPolicy> jsonNodes;
			int index;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyPolicy>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyPolicy>();
				}
				CompanyPolicy toRemove = jsonNodes.Where<CompanyPolicy>(alu => alu.Id.Equals(companyPolicy.Id)).First();
				index = jsonNodes.IndexOf(toRemove);
				jsonNodes.Remove(toRemove);
				jsonNodes.Insert(index, companyPolicy);

				var resultJSONList = Json<CompanyPolicy>.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);

				return Json<CompanyPolicy>.DeserializeObject(fm.RetrieveData())[index];
			}
			catch (InvalidOperationException)
			{
				LogManager.LogError();
				return null;
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
				fm.DeleteFile();
				fm.CreateFile();
			}
			catch (VuelingException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ClearError, ex);
			}
		}
	}
}
