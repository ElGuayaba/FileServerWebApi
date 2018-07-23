﻿using FileServer.Application.Services.Contract;
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
	[Authorize]
	public class PoliciesController : ApiController
    {
		public readonly IServiceOperations<CompanyPolicy> iService = new CompanyPolicyService();
		public PoliciesController() : this(new CompanyPolicyService())
		{

		}
		public PoliciesController(CompanyPolicyService CompanyPolicyService)
		{
			this.iService = CompanyPolicyService;
		}
		// GET: api/CompanyPolicy
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
		public IHttpActionResult Get(Guid id)
		{
			try
			{
				CompanyPolicy CompanyPolicy = iService.GetByID(id).First();
				return Ok(CompanyPolicy);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
		}

		// POST: api/CompanyPolicy
		[ResponseType(typeof(CompanyPolicy))]
		public IHttpActionResult Post(CompanyPolicy CompanyPolicy)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				CompanyPolicy CompanyPolicyInserted =
						iService.Add(CompanyPolicy);
			}
			catch (Exception)
			{
				throw;
			}

			return CreatedAtRoute("DefaultApi",
				new { id = CompanyPolicy.Id }, CompanyPolicy);
		}

		// PUT: api/CompanyPolicy/5
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
			catch (Exception)
			{

				throw;
			}
		}

		// DELETE: api/CompanyPolicy/5
		public IHttpActionResult Delete(Guid id)
		{
			CompanyPolicy CompanyPolicy;
			try
			{
				CompanyPolicy = iService.GetByID(id).First();
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
			//Manejar la otra excepción
			iService.Remove(CompanyPolicy.Id);
			return Ok(CompanyPolicy);
		}
	}
}
