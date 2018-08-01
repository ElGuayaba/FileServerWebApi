using FileServer.Application.Service.Contract;
using FileServer.Application.Service.Service;
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
	/// <summary>
	/// Controller in charge of managing access to the client database.
	/// </summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	[Authorize]
	public class ClientsController : ApiController
    {
		/// <summary>
		/// The service interface used to call the application layer.
		/// </summary>
		public readonly ICompanyClientService iService;
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientsController"/> class.
		/// </summary>
		public ClientsController() : this(new CompanyClientService())
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientsController"/> class.
		/// </summary>
		/// <param name="CompanyClientService">The company client service.</param>
		public ClientsController(CompanyClientService CompanyClientService)
		{
			this.iService = CompanyClientService;
		}
		// GET: api/Clients
		/// <summary>
		/// Gets all Clients.
		/// </summary>
		/// <returns>A set of clients as a queriable object</returns>
		/// <exception cref="HttpResponseException"></exception>
		[Authorize(Roles = "admin")]
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
		/// <summary>
		/// Gets the specified Client.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>OK if successful, NotFound otherwise.</returns>
		[Authorize(Roles = "admin, user")]
		public IHttpActionResult Get(Guid id)
		{
			try
			{
				CompanyClient CompanyClient = iService.GetByID(id);
				return Ok(CompanyClient);
			}
			catch (VuelingException)
			{
				return NotFound();
			}
		}

		// GET: api/Clients/John
		/// <summary>
		/// Gets the specified Client.
		/// </summary>
		/// <param name="name">The identifier.</param>
		/// <returns>OK if successful, NotFound otherwise.</returns>
		[Authorize(Roles = "admin, user")]
		[Route("api/GetByName")]
		public IHttpActionResult Get(string name)
		{
			try
			{
				CompanyClient CompanyClient = iService.GetByName(name).First();
				return Ok(CompanyClient);
			}
			catch (VuelingException)
			{
				return NotFound();
			}
		}


		// POST: api/Clients
		/// <summary>
		/// Posts the specified company client.
		/// </summary>
		/// <param name="CompanyClient">The company client.</param>
		/// <returns>Creation route if successful, BadRequest otherwise.</returns>
		/// <exception cref="HttpResponseException"></exception>
		[ResponseType(typeof(CompanyClient))]
		[Authorize(Roles = "admin")]
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
		/// <summary>
		/// Updates the specified Client.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="CompanyClient">The company client.</param>
		/// <returns>
		/// NoContent if successful, NotFound if the identifier is not listed,
		///  BadRequest in any other cases.
		/// </returns>
		/// <exception cref="HttpResponseException"></exception>
		[Authorize(Roles = "admin")]
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
		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// OK if successful, NotFound if the identifier is not listed,
		/// BadRequest in any other cases.
		/// </returns>
		/// <exception cref="HttpResponseException"></exception>
		[Authorize(Roles = "admin")]
		public IHttpActionResult Delete(Guid id)
		{
			CompanyClient CompanyClient;
			try
			{
				CompanyClient = iService.GetByID(id);
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
