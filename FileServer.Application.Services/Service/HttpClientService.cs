﻿using System;
using System.Collections.Generic;
using System.Linq;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Net;

namespace FileServer.Application.Service
{
	/// <summary>
	/// Controller in charge of getting information from a webapi
	/// </summary>
	public class HttpClientService
	{
		/// <summary>
		/// The client
		/// </summary>
		static WebClient client;
		/// <summary>
		/// Initializes the <see cref="HttpClientService"/> class.
		/// </summary>
		static HttpClientService()
		{
			client = new WebClient();
		}

		/// <summary>
		/// Gets the call.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="VuelingException"></exception>
		public static List<CompanyClient> GetCall()
		{
			ArrayEntity<CompanyClient> listClients;
			try
			{
				var clientJsonString = client.DownloadString(Properties.Settings.Default.ClientRoute);
				listClients = Json<ArrayEntity<CompanyClient>>.DeserializeObjectArray(clientJsonString);

				return listClients.clients.OfType<CompanyClient>().ToList();
			}
			catch (ArgumentNullException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.ArgumentNull, ex);
			}
			catch (WebException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.WebError, ex);
			}
			catch (NotSupportedException ex)
			{
				LogManager.LogError();
				throw new VuelingException(Resources.NotSupported, ex);
			}
		}
	}
}
