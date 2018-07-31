using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileServer.Facade.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http.Results;
using FileServer.Common.Entities;

namespace FileServer.Facade.WebApi.Controllers.Tests
{
	[TestClass()]
	public class LoginControllerTests
	{
		private string baseurl;
		public LoginControllerTests()
		{
			baseurl = "http://localhost:52058";
		}

		[TestMethod()]
		public void EchoPingTest()
		{
			string url = baseurl + "/api/login/echoping";

			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			// Sends the HttpWebRequest and waits for a response.
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

			var statusCode = myHttpWebResponse.StatusCode;
			Assert.AreEqual(statusCode, HttpStatusCode.OK);
		}

		[TestMethod()]
		public void AuthenticateTest()
		{
			Assert.Fail();
		}
	}
}