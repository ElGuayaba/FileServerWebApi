using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Layer
{
	public class FileManager
	{
		public string FileExtension { get; set; }
		public string FilePath { get; set; }

		public FileManager()
		{
			FilePath = Environment.GetEnvironmentVariable("VUELING_HOME") 
				+ "AlumnosWebApi.json";
		}

		public void CreateFile()
		{
			if (!FileExists())
			{
				try
				{
					using (StreamWriter file = new StreamWriter(FilePath, true)) { }
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public bool FileExists()
		{
			return File.Exists(FilePath);
		}

		public string RetrieveData()
		{
			try
			{
				var jsonData = File.ReadAllText(FilePath);
				return jsonData;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void WriteToFile(string fileData)
		{
			try
			{
				File.WriteAllText(FilePath, fileData);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Alumno ProcessAlumnoData(Alumno alumno)
		{
			List<Alumno> jsonNodes;
			try
			{
				CreateFile();
				var data = RetrieveData();
				jsonNodes = Deserialize(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<Alumno>();
				}
				jsonNodes.Add(alumno);

				var resultJSONList = SerializeIndented(jsonNodes);
				WriteToFile(resultJSONList);
				return Deserialize(RetrieveData()).Last();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string SerializeIndented(List<Alumno> jsonNodes)
		{
			return JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
		}

		public List<Alumno> Deserialize(string jsondata)
		{
			return JsonConvert.DeserializeObject<List<Alumno>>(jsondata);
		}
	}
}
