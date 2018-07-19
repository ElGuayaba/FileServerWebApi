using FileServer.Application.Services.Contract;
using FileServer.Common.Entities;
using FileServer.Infrastructure.Repository.Contract;
using FileServer.Infrastructure.Repository.Repository;
using System.Collections.Generic;
using FileServer.Common.Layer;

namespace FileServer.Application.Services.Service
{
	/// <summary>
	/// Service class for Alumno objects.
	/// </summary>
	/// <seealso cref="FileServer.Application.Services.Contract.IServiceOperations{FileServer.Common.Entities.Alumno}" />
	public class AlumnoService : IServiceOperations<Alumno>
	{
		/// <summary>
		/// Generic repository.
		/// </summary>
		private readonly IRepositoryOperations<Alumno> iRepository;
		/// <summary>
		/// Initializes a new instance of the <see cref="AlumnoService"/> class.
		/// </summary>
		public AlumnoService() : this(new AlumnoRepository())
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="AlumnoService"/> class.
		/// </summary>
		/// <param name="alumnoRepository">The alumno repository.</param>
		public AlumnoService(AlumnoRepository alumnoRepository)
		{
			this.iRepository = alumnoRepository;
		}
		/// <summary>
		/// Adds the specified Alumno object.
		/// </summary>
		/// <param name="alumno">The alumno.</param>
		/// <returns></returns>
		public Alumno Add(Alumno alumno)
		{
			try
			{
				return iRepository.Add(alumno);
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.AddError, ex);
			}
		}

		/// <summary>
		/// Gets all objects from the storage entity.
		/// </summary>
		/// <returns></returns>
		public List<Alumno> GetAll()
		{
			try
			{
				return iRepository.GetAll();
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Gets objects from the storage entity by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public List<Alumno> GetByID(int id)
		{
			try
			{
				return iRepository.GetByID(id);
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.GetError, ex);
			}
		}

		/// <summary>
		/// Removes the specified identifier from the storage entity.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public bool Remove(int id)
		{
			try
			{
				return iRepository.Remove(id);
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.DeleteError, ex);
			}
		}

		/// <summary>
		/// Updates the specified alumno.
		/// </summary>
		/// <param name="alumno">The alumno.</param>
		/// <returns></returns>
		public Alumno Update(Alumno alumno)
		{
			try
			{
				return iRepository.Update(alumno);
			}
			catch (VuelingException ex)
			{
				throw new VuelingException(Resources.UpdateError, ex);
			}
		}
	}
}
