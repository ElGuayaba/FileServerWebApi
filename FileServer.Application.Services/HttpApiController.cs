using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FileServer.Common.Entities;
using FileServer.Common.Layer;
using System.Text;

namespace FileServer.Application.Services
{
	/// <summary>
	/// Controller in charge of getting information from a webapi
	/// </summary>
	public class HttpApiController
	{
		/// <summary>
		/// The client
		/// </summary>
		static HttpClient client;
		/// <summary>
		/// Initializes the <see cref="HttpApiController"/> class.
		/// </summary>
		static HttpApiController()
		{
			client = new HttpClient
			{
				BaseAddress = new Uri("http://localhost:59084/")
			};
		}

		/// <summary>
		/// Gets the call.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="VuelingException">
		/// </exception>
		public static async Task<List<Alumno>> GetCall()
		{
			LogManager.LogDebug("Haciendo el get");
			IEnumerable<Alumno> listaAlumnos = null;
			try
			{
				HttpResponseMessage response = client.GetAsync("api/Alumnos").Result;
				if (response.IsSuccessStatusCode)
				{
					var alumnoJsonString = await response.Content.ReadAsStringAsync();
					listaAlumnos = Json.DeserializeAlumnos(alumnoJsonString);
				}
			}
			catch (ArgumentNullException ex)
			{
				throw new VuelingException(Resources.ArgumentNull, ex);
			}
			catch (HttpRequestException ex)
			{
				throw new VuelingException(Resources.HttpReq, ex);
			}
			return listaAlumnos.ToList();
		}

		/// <summary>
		/// Añadirs the alumnos.
		/// </summary>
		/// <param name="alumno">The alumno.</param>
		/// <exception cref="VuelingException"></exception>
		public static async void AñadirAlumnos(Alumno alumno)
		{
			var alumnoJSON = Json.SerializeIndented(alumno);

			try
			{
				var encodingToBytes = Encoding.UTF8.GetBytes(alumnoJSON);
				var byteContent = new ByteArrayContent(encodingToBytes);
				
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				var result = await client.PostAsync("api/Alumnos", byteContent);

			}
			catch (ArgumentNullException ex)
			{
				throw new VuelingException(Resources.ArgumentNull, ex);
			}
		}
	}
}
