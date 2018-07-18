using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Common.Entities;

namespace FileServer.Infrastructure.Repository.Repository
{
	public class AlumnoRepository : IRepositoryQueries<Alumno>, IRepositoryOperations<Alumno>
	{
		public Alumno Add(Alumno model)
		{
			throw new NotImplementedException();
		}

		public List<Alumno> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<Alumno> GetByID()
		{
			throw new NotImplementedException();
		}

		public int Remove(int id)
		{
			throw new NotImplementedException();
		}

		public Alumno Update(Alumno model)
		{
			throw new NotImplementedException();
		}
	}
}
