using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Common.Entities;
using FileServer.Common.Layer;

namespace FileServer.Infrastructure.Repository.Repository
{
	public class AlumnoRepository : IRepositoryQueries<Alumno>, IRepositoryOperations<Alumno>
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
			catch (Exception)
			{
				throw;
			}			
		}

		public List<Alumno> GetAll()
		{
			try
			{
				var data = fm.RetrieveData();
				return fm.Deserialize(data);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public List<Alumno> GetByID(int id)
		{
			try
			{
				var data = fm.RetrieveData();
				return fm.Deserialize(data).Where(alu => alu.Id == id).ToList();
			}
			catch (Exception)
			{
				throw;
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
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Alumno Update(Alumno model)
		{
			throw new NotImplementedException();
		}
	}
}
