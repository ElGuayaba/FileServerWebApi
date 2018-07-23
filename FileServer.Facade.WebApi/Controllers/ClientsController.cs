using FileServer.Application.Services.Contract;
using FileServer.Application.Services.Service;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FileServer.Facade.WebApi.Controllers
{
	[Authorize]
	public class ClientsController : ApiController
    {
		public readonly IServiceOperations<CompanyClient> iService = new CompanyClientService();
		public ClientsController() : this(new CompanyClientService())
		{

		}
		public ClientsController(CompanyClientService CompanyClientService)
		{
			this.iService = CompanyClientService;
		}
		// GET: api/Clients
		public IQueryable<CompanyClient> Get()
		{
			try
			{
				return iService.GetAll().AsQueryable<CompanyClient>();
			}
			catch (VuelingException)
			{
				throw new HttpResponseException(HttpStatusCode.NoContent);
			}
		}

		// GET: api/Clients/5
		public IHttpActionResult Get(Guid id)
		{
			try
			{
				CompanyClient CompanyClient = iService.GetByID(id).First();
				return Ok(CompanyClient);
			}
			catch (VuelingException)
			{
				return NotFound();
			}
		}

		// POST: api/Clients
		[ResponseType(typeof(CompanyClient))]
		public IHttpActionResult Post(CompanyClient CompanyClient)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				CompanyClient CompanyClientInserted =
						iService.Add(CompanyClient);
			}
			catch (VuelingException)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			return CreatedAtRoute("DefaultApi",
				new { id = CompanyClient.Id }, CompanyClient);
		}

		// PUT: api/Clients/5
		public IHttpActionResult Put(Guid id, CompanyClient CompanyClient)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (!id.Equals(CompanyClient.Id))
			{
				return BadRequest();
			}
			try
			{
				CompanyClient = iService.Update(CompanyClient);
				if (CompanyClient == null)
				{
					return NotFound();
				}
				else
				{
					return StatusCode(HttpStatusCode.NoContent);
				}
			}
			catch (VuelingException)
			{

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
		}

		// DELETE: api/Clients/5
		public IHttpActionResult Delete(Guid id)
		{
			CompanyClient CompanyClient;
			try
			{
				CompanyClient = iService.GetByID(id).First();
				iService.Remove(CompanyClient.Id);
				return Ok(CompanyClient);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}catch (VuelingException)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			
		}
	}
}
