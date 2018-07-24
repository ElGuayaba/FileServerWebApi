using System;
using System.Collections.Generic;
using System.Linq;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Common.Entities;
using FileServer.Common.Layer;

namespace FileServer.Infrastructure.Repository.Repository
{
	/// <summary>
	/// Repository class for Alumno objects.
	/// </summary>
	/// <seealso cref="FileServer.Infrastructure.Repository.Contract.IRepositoryOperations{FileServer.Common.Entities.CompanyClient}" />
	public class CompanyClientRepository : IRepositoryOperations<CompanyClient>
	{
		/// <summary>
		/// The filemanager
		/// </summary>
		private FileManager fm;
		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyClientRepository"/> class.
		/// </summary>
		public CompanyClientRepository()
		{
			fm = new FileManager(Properties.Settings.Default.ClientsFile);
			fm.CreateFile();
		}

		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="companyClient">Alumno object to be added.</param>
		/// <returns>The object added if successful, null otherwise</returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Add(CompanyClient companyClient)
		{
			List<CompanyClient> jsonNodes;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyClient>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyClient>();
				}
				jsonNodes.Add(companyClient);

				var resultJSONList = Json<CompanyClient>.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);
				return Json<CompanyClient>.DeserializeObject(fm.RetrieveData()).Last();
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
		public List<CompanyClient> GetAll()
		{
			try
			{
				var data = fm.RetrieveData();
				return Json<CompanyClient>.DeserializeObject(data);
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
		public List<CompanyClient> GetByID(Guid id)
		{
			try
			{
				var data = fm.RetrieveData();
				return Json<CompanyClient>.DeserializeObject(data).Where(alu => alu.Id.Equals(id)).ToList();
			}
			catch (VuelingException ex)
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
			List<CompanyClient> jsonNodes;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyClient>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyClient>();
				}
				CompanyClient companyClient = jsonNodes.Where<CompanyClient>(alu => alu.Id.Equals(id)).First();
				jsonNodes.Remove(companyClient);

				var resultJSONList = Json<CompanyClient>.SerializeIndented(jsonNodes);
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
		/// <param name="companyClient">The object to be inserted.</param>
		/// <returns>
		/// The inserted object.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public CompanyClient Update(CompanyClient companyClient)
		{
			List<CompanyClient> jsonNodes;
			int index;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = Json<CompanyClient>.DeserializeObject(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<CompanyClient>();
				}
				CompanyClient toRemove = jsonNodes.Where<CompanyClient>(alu => alu.Id.Equals(companyClient.Id)).First();
				index = jsonNodes.IndexOf(toRemove);
				jsonNodes.Remove(toRemove);
				jsonNodes.Insert(index, companyClient);

				var resultJSONList = Json<CompanyClient>.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);

				return Json<CompanyClient>.DeserializeObject(fm.RetrieveData())[index];
			}
			catch (InvalidOperationException)
			{
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
