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
	/// Controller in charge of handling policy-related petitions
	/// </summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	[Authorize]
	public class PoliciesController : ApiController
    {
		/// <summary>
		/// The service that will perform operations
		/// </summary>
		public readonly ICompanyPolicyService iService;

		//}
		/// <summary>
		/// Initializes a new instance of the <see cref="PoliciesController"/> class.
		/// </summary>
		/// <param name="CompanyPolicyService">The company policy service.</param>
		public PoliciesController(ICompanyPolicyService CompanyPolicyService)
		{
			this.iService = CompanyPolicyService;
		}
		// GET: api/CompanyPolicy
		/// <summary>
		/// Gets all policies.
		/// </summary>
		/// <returns>A set of policies as a queryable object</returns>
		[Authorize(Roles = "admin")]
		public IQueryable<CompanyPolicy> Get()
		{
			try
			{
				return iService.GetAll().AsQueryable<CompanyPolicy>();
			}
			catch (Exception)
			{

				throw;
			}
		}

		// GET: api/CompanyPolicy/5
		/// <summary>
		/// Gets a policy based on a specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A policy if successful, NotFound otherwise</returns>
		[Authorize(Roles = "admin")]
		public IHttpActionResult Get(Guid id)
		{
			try
			{
				CompanyPolicy CompanyPolicy = iService.GetByID(id);
				return Ok(CompanyPolicy);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
		}

		// GET: api/CompanyPolicy/5
		/// <summary>
		/// Gets the client associated to a policy number.
		/// </summary>
		/// <param name="policyId">The policy identifier.</param>
		/// <returns>A policy if successful, NotFound otherise</returns>
		[Authorize(Roles = "admin")]
		[Route("api/GetClient")]
		public IHttpActionResult GetClient(Guid policyId)
		{
			try
			{
				CompanyClient companyClient = iService.GetClient(policyId);
				return Ok(companyClient);
			}
			catch (VuelingException)
			{
				return NotFound();
			}
		}

		// POST: api/CompanyPolicy
		/// <summary>
		/// Posts the specified company policy to he database.
		/// </summary>
		/// <param name="CompanyPolicy">The company policy.</param>
		/// <returns>
		/// The route of creation
		/// </returns>
		[ResponseType(typeof(CompanyPolicy))]
		[Authorize(Roles = "admin")]
		public IHttpActionResult Post(CompanyPolicy companyPolicy)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				CompanyPolicy CompanyPolicyInserted =
						iService.Add(companyPolicy);
			}
			catch (VuelingException)
			{
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

			return CreatedAtRoute("DefaultApi",
				new { id = companyPolicy.Id }, companyPolicy);
		}

		// PUT: api/CompanyPolicy/5
		/// <summary>
		/// Updates the specified identifier on the storage entity.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="CompanyPolicy">The company policy object.</param>
		/// <returns>
		/// NoContent if successful, NotFound if the identifier is not listed,
		///  BadRequest in any other cases.
		/// </returns>
		[Authorize(Roles = "admin")]
		public IHttpActionResult Put(Guid id, CompanyPolicy CompanyPolicy)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (!id.Equals(CompanyPolicy.Id))
			{
				return BadRequest();
			}
			try
			{
				CompanyPolicy = iService.Update(CompanyPolicy);
				if (CompanyPolicy == null)
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

		// DELETE: api/CompanyPolicy/5
		/// <summary>
		/// Deletes an entry based on the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// OK if successful, NotFound if the identifier is not listed,
		/// BadRequest in any other cases.
		/// </returns>
		[Authorize(Roles = "admin")]
		public IHttpActionResult Delete(Guid id)
		{
			CompanyPolicy CompanyPolicy;
			try
			{
				CompanyPolicy = iService.GetByID(id);
				iService.Remove(CompanyPolicy.Id);
				return Ok(CompanyPolicy);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
			catch (VuelingException)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
		}
	}
}
