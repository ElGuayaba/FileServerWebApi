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
			try
			{
				return iService.GetAll().AsQueryable<Alumno>();
			}
			catch (Exception)
			{

				throw;
			}
		}

		// GET: api/Alumno/5
		public IHttpActionResult Get(int id)
		{
			try
			{
				Alumno alumno = iService.GetByID(id).First();
				return Ok(alumno);
			}
			catch (InvalidOperationException ex)
			{
				return NotFound();
			}
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
		public IHttpActionResult Put(int id, Alumno alumno)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (id != alumno.Id)
			{
				return BadRequest();
			}
			try
			{
				alumno = iService.Update(alumno);
				if (alumno == null)
				{
					return NotFound();
				}
				else
				{
					return StatusCode(HttpStatusCode.NoContent);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		// DELETE: api/Alumno/5
		public IHttpActionResult Delete(int id)
		{
			Alumno alumno;
			try
			{
				alumno = iService.GetByID(id).First();
			}
			catch (InvalidOperationException ex)
			{
				return NotFound();
			}
			//Manejar la otra excepción
			iService.Remove(alumno.Id);
			return Ok(alumno);
		}
	}
}
