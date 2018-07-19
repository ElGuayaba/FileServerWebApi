using System;
using System.Collections.Generic;
using System.Linq;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Resources;

namespace FileServer.Infrastructure.Repository.Repository
{
	public class AlumnoRepository : IRepositoryOperations<Alumno>
	{
		private FileManager fm;
		public AlumnoRepository()
		{
			this.fm = new FileManager();
			fm.CreateFile();
		}

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
			catch (InvalidOperationException ex)
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
