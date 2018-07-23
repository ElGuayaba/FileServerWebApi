using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FileServer.Common.Entities;

namespace FileServer.Common.Layer
{
	public static class Json<T>
	{
		/// <summary>
		/// Serializes Alumno objects in a List to json (indented) format.
		/// </summary>
		/// <param name="jsonNodes">The list to be serialized</param>
		/// <returns>
		/// The string of serialized objects
		/// </returns>
		public static string SerializeIndented(List<T> jsonNodes)
		{
			return JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
		}

		/// <summary>
		/// Serializes Alumno object to json (indented) format.
		/// </summary>
		/// <param name="jsonNodes">The object to be serialized</param>
		/// <returns>
		/// The string of serialized objects
		/// </returns>
		public static string SerializeIndented(T jsonNode)
		{
			return JsonConvert.SerializeObject(jsonNode, Formatting.Indented);
		}

		/// <summary>
		/// Deserializes the specified jsondata.
		/// </summary>
		/// <param name="jsondata">A string in json format.</param>
		/// <returns>
		/// A list of Alumno objects.
		/// </returns>
		public static List<T> DeserializeObject(string jsondata)
		{
			return JsonConvert.DeserializeObject<List<T>>(jsondata);
		}

		public static T DeserializeObjectArray(string jsondata)
		{
			//CompanyPolicy[] list = new CompanyPolicy[200];
			return JsonConvert.DeserializeObject<T>(jsondata);
		}
	}
}
