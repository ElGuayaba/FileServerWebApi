using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Entities;
using FileServer.Common.Layer;

namespace FileServer.Application.Services
{
	class HttpApiController
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
			catch (Exception ex)
			{
				throw ex;
			}
			return listaAlumnos.ToList();
		}

		public static async void AñadirAlumnos(Alumno alumno)
		{
			// Serializacion del objeto alumno
			var alumnoJSON = Json.SerializeIndented(alumno);

			try
			{
				// Creacion de objeto de contenido para enviar la informacion
				var encodingToBytes = System.Text.Encoding.UTF8.GetBytes(alumnoJSON);
				var byteContent = new ByteArrayContent(encodingToBytes);

				// Especificamos en el header que se trata de un tipo JSON
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				var result = await client.PostAsync("api/Alumnos", byteContent);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
