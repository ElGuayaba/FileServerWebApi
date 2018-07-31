using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileServer.Facade.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FileServer.Common.Entities;
using System.Net;
using FileServer.Common.Layer;

namespace FileServer.Facade.WebApi.Controllers.Tests
{
	[TestClass()]
	public class ClientsControllerTests
	{
		private string baseurl;
		IWebDriver driver;
		public ClientsControllerTests()
		{
			baseurl = "http://localhost:52058";
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();

		}

		[TestMethod()]
		public void GetTest()
		{
			CompanyClient dummy = new CompanyClient
			{
				Id = Guid.Parse("a0ece5db-cd14-4f21-812f-966633e7be86"),
				Name = "Britney",
				Email = "britneyblankenship@quotezart.com",
				Role = "admin"
			};
			List<CompanyClient> listClients;
			WebClient client = new WebClient();
			string url = baseurl + "/api/Clients";
			var clientJsonString = client.DownloadString(url);
			listClients = Json<CompanyClient>.DeserializeObject(clientJsonString);
			CompanyClient firstClient = listClients.FirstOrDefault();
			Assert.Equals(firstClient,dummy);
		}

		[TestMethod()]
		public void GetTest1()
		{
			string url = baseurl + "/api/Clients";
			driver.Navigate().GoToUrl(url);
			var responseElement = (CompanyClient)driver.FindElement(By.TagName("CompanyClient"));
			Assert.IsNotNull(responseElement);
		}

		[TestMethod()]
		public void GetTest2()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PostTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PutTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}
	}
}