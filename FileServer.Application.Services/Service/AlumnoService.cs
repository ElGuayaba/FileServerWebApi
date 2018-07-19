using FileServer.Application.Services.Contract;
using FileServer.Common.Entities;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;

namespace FileServer.Application.Services.Service
{
	public class AlumnoService : IServiceOperations<Alumno>
	{
		private readonly IRepositoryOperations<Alumno> iRepository;
		public AlumnoService() : this(new AlumnoRepository())
		{

		}
		public AlumnoService(AlumnoRepository alumnoRepository)
		{
			this.iRepository = alumnoRepository;
		}
		public Alumno Add(Alumno alumno)
		{
			try
			{
				return iRepository.Add(alumno);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public List<Alumno> GetAll()
		{
			try
			{
				return iRepository.GetAll();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public List<Alumno> GetByID(int id)
		{
			try
			{
				return iRepository.GetByID(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public bool Remove(int id)
		{
			try
			{
				return iRepository.Remove(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public Alumno Update(Alumno alumno)
		{
			try
			{
				return iRepository.Update(alumno);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
