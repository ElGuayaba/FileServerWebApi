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

		public int Remove(int id)
		{
			throw new NotImplementedException();
		}

		public Alumno Update(Alumno model)
		{
			throw new NotImplementedException();
		}

		//-------------DELETE-------------
		public static void Main(String[] args)
		{
			
		}
	}
}
