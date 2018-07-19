using FileServer.Application.Services.Contract;
using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FileServer.Facade.WebApi.Controllers
{
    public class AlumnoController : ApiController
    {
		public readonly IServiceOperations<Alumno> iService = new AlumnoService();
		public AlumnoController() : this(new AlumnoService())
		{

		}
		public AlumnoController(AlumnoService alumnoService)
		{
			this.iService = alumnoService;
		}
		// GET: api/Alumno
		public IQueryable<Alumno> Get()
		{
			throw new NotImplementedException();
			//return alumnoService.GetAll();
		}

		// GET: api/Alumno/5
		public IHttpActionResult Get(int id)
		{
			throw new NotImplementedException();
			//return alumnoService.GetByID(id);
			//Rerotna ok alumno
		}

		// POST: api/Alumno
		[ResponseType(typeof(Alumno))]
		public IHttpActionResult Post(Alumno alumno)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				Alumno AlumnoInserted =
						iService.Add(alumno);
			}
			catch (Exception)
			{
				throw;
			}

			return CreatedAtRoute("DefaultApi",
				new { id = alumno.Id }, alumno);
		}

		// PUT: api/Alumno/5
		public bool Put(Alumno alumno)
		{
			throw new NotImplementedException();
			//alumnoService.Update(alumno);
			//return true;
			//Devuelce status code no content
		}

		// DELETE: api/Alumno/5
		public IHttpActionResult Delete(int id)
		{
			throw new NotImplementedException();
			//return alumnoService.Remove(id);
		}
	}
}
