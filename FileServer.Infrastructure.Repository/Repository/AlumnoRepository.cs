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
	/// <seealso cref="FileServer.Infrastructure.Repository.Contract.IRepositoryOperations{FileServer.Common.Entities.Alumno}" />
	public class AlumnoRepository : IRepositoryOperations<Alumno>
	{
		/// <summary>
		/// The filemanager
		/// </summary>
		private FileManager fm;
		/// <summary>
		/// Initializes a new instance of the <see cref="AlumnoRepository"/> class.
		/// </summary>
		public AlumnoRepository()
		{
			this.fm = new FileManager();
			fm.CreateFile();
		}

		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="alumno">Alumno object to be added.</param>
		/// <returns>The object added if successful, null otherwise</returns>
		/// <exception cref="VuelingException"></exception>
		public Alumno Add(Alumno alumno)
		{
			try
			{
				return fm.ProcessAlumnoData(alumno);
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.AddError, ex);
			}			
		}

		/// <summary>
		/// Gets all objects from sotrage file.
		/// </summary>
		/// <returns>
		/// The objects stored in a list.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public List<Alumno> GetAll()
		{
			try
			{
				var data = fm.RetrieveData();
				return fm.Deserialize(data);
			}
			catch (VuelingException ex)
			{
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
		public List<Alumno> GetByID(int id)
		{
			try
			{
				var data = fm.RetrieveData();
				return fm.Deserialize(data).Where(alu => alu.Id == id).ToList();
			}
			catch (VuelingException ex)
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
		public bool Remove(int id)
		{
			List<Alumno> jsonNodes;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = fm.Deserialize(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<Alumno>();
				}
				Alumno alumno = jsonNodes.Where<Alumno>(alu => alu.Id == id).First();
				jsonNodes.Remove(alumno);

				var resultJSONList = fm.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);
				return true;
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.DeleteError, ex);
			}
		}

		/// <summary>
		/// Updates the specified Alumno object.
		/// </summary>
		/// <param name="alumno">The object to be inserted.</param>
		/// <returns>
		/// The inserted object.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public Alumno Update(Alumno alumno)
		{
			List<Alumno> jsonNodes;
			int index;
			try
			{
				var data = fm.RetrieveData();
				jsonNodes = fm.Deserialize(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<Alumno>();
				}
				Alumno toRemove = jsonNodes.Where<Alumno>(alu => alu.Id == alumno.Id).First();
				index = jsonNodes.IndexOf(toRemove);
				jsonNodes.Remove(toRemove);
				jsonNodes.Insert(index, alumno);

				var resultJSONList = fm.SerializeIndented(jsonNodes);
				fm.WriteToFile(resultJSONList);

				return fm.Deserialize(fm.RetrieveData())[index];
			}
			catch (InvalidOperationException)
			{
				return null;
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.UpdateError, ex);
			}
		}
	}
}
