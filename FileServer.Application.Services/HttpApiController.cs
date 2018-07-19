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
	public class HttpApiController
	{
		static HttpClient client;
		static HttpApiController()
		{
			client = new HttpClient
			{
				BaseAddress = new Uri("http://localhost:59084/")
			};
		}

		public static async Task<List<Alumno>> GetCall()
		{
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
