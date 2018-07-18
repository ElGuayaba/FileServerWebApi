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

		public FileManager(int filePathType)
		{
			FileExtension = ConfigurationManager.AppSettings.Get("jsonFile");
			FilePath = Environment.GetEnvironmentVariable("VUELING_HOME") + "AlumnosWebApi" + FileExtension;
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
			List<Alumno> jsonNodes = null;
			try
			{
				CreateFile();
				var data = RetrieveData();
				jsonNodes = JsonConvert.DeserializeObject<List<Alumno>>(data);
				if (jsonNodes == null)
				{
					jsonNodes = new List<Alumno>();
				}
				jsonNodes.Add(alumno);

				var resultJSONList = JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
				WriteToFile(resultJSONList);
				return JsonConvert.DeserializeObject<List<Alumno>>(RetrieveData()).Last();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
