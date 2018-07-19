using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using FileServer.Common.Layer.Resources;

namespace FileServer.Common.Layer
{
	/// <summary>
	/// This class is in charge of managing the access to the storage file.
	/// </summary>
	public class FileManager
	{
		/// <summary>
		/// Gets or sets the file path.
		/// </summary>
		/// <value>
		/// The file path.
		/// </value>
		public string FilePath { get; set; }
		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		/// <value>
		/// The name of the file.
		/// </value>
		public string FileName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="FileManager"/> class.
		/// </summary>
		public FileManager()
		{
			FileName = FMResources.FileName;
			FilePath = FMResources.FilePath + FileName;
		}

		/// <summary>
		/// Creates the file if it doesn't exist.
		/// </summary>
		/// <exception cref="VuelingException"></exception>
		public void CreateFile()
		{
			if (!FileExists())
			{
				try
				{
					using (StreamWriter file = new StreamWriter(FilePath, true)) { }
				}
				catch (UnauthorizedAccessException ex)
				{

					throw new VuelingException(FMResources.Unauthorized, ex);
				}
				catch (ArgumentNullException ex)
				{
					throw new VuelingException(FMResources.ArgumentNull, ex);
				}
				catch (ArgumentException ex)
				{
					throw new VuelingException(FMResources.Argument, ex);
				}
				catch (DirectoryNotFoundException ex)
				{
					throw new VuelingException(FMResources.NotFound, ex);
				}
				catch (PathTooLongException ex)
				{
					throw new VuelingException(FMResources.PathTooLong, ex);
				}
				catch (IOException ex)
				{
					throw new VuelingException(FMResources.IO, ex);
				}
			}
		}

		/// <summary>
		/// Checks if the storage file exists.
		/// </summary>
		/// <returns>
		/// A boolean value that is true if the file exists, false otherwise.
		/// </returns>
		public bool FileExists()
		{
			return File.Exists(FilePath);
		}

		/// <summary>
		/// Retrieves the data from the storage file as a string.
		/// </summary>
		/// <returns>
		/// The data contained in the storage file
		/// </returns>
		/// <exception cref="VuelingException"></exception>
		public string RetrieveData()
		{
			try
			{
				var jsonData = File.ReadAllText(FilePath);
				return jsonData;
			}
			catch (UnauthorizedAccessException ex)
			{

				throw new VuelingException(FMResources.Unauthorized, ex);
			}
			catch (ArgumentNullException ex)
			{
				throw new VuelingException(FMResources.ArgumentNull, ex);
			}
			catch (ArgumentException ex)
			{
				throw new VuelingException(FMResources.Argument, ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new VuelingException(FMResources.NotFound, ex);
			}
			catch (PathTooLongException ex)
			{
				throw new VuelingException(FMResources.PathTooLong, ex);
			}
			catch (IOException ex)
			{
				throw new VuelingException(FMResources.IO, ex);
			}
			catch (NotSupportedException ex)
			{
				throw new VuelingException(FMResources.NotSupported, ex);
			}
		}

		/// <summary>
		/// Writes formatted data to the storage file.
		/// </summary>
		/// <param name="fileData">Formatted data.</param>
		/// <exception cref="VuelingException"></exception>
		public void WriteToFile(string fileData)
		{
			try
			{
				File.WriteAllText(FilePath, fileData);
			}
			catch (UnauthorizedAccessException ex)
			{

				throw new VuelingException(FMResources.Unauthorized, ex);
			}
			catch (ArgumentNullException ex)
			{
				throw new VuelingException(FMResources.ArgumentNull, ex);
			}
			catch (ArgumentException ex)
			{
				throw new VuelingException(FMResources.Argument, ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new VuelingException(FMResources.NotFound, ex);
			}
			catch (PathTooLongException ex)
			{
				throw new VuelingException(FMResources.PathTooLong, ex);
			}
			catch (IOException ex)
			{
				throw new VuelingException(FMResources.IO, ex);
			}
			catch (NotSupportedException ex)
			{
				throw new VuelingException(FMResources.NotSupported, ex);
			}
		}

		/// <summary>
		/// Processes data from an Alumno object and stores it in the file.
		/// </summary>
		/// <param name="alumno">The alumno object to be stored in the storage file
		/// </param>
		/// <returns>
		/// The inserted Alumno if the operation is successful, null otherwise.
		/// </returns>
		/// <exception cref="VuelingException"></exception>
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
			catch (InvalidOperationException)
			{
				return null;
			}
			catch (ArgumentNullException ex)
			{
				throw new VuelingException(FMResources.ArgumentNull,ex);
			}
		}

		/// <summary>
		/// Serializes Alumno objects in a List to json (indented) format.
		/// </summary>
		/// <param name="jsonNodes">The list to be serialized</param>
		/// <returns>
		/// The string of serialized objects
		/// </returns>
		public string SerializeIndented(List<Alumno> jsonNodes)
		{
			return JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
		}

		/// <summary>
		/// Deserializes the specified jsondata.
		/// </summary>
		/// <param name="jsondata">A string in json format.</param>
		/// <returns>
		/// A list of Alumno objects.
		/// </returns>
		public List<Alumno> Deserialize(string jsondata)
		{
			return JsonConvert.DeserializeObject<List<Alumno>>(jsondata);
		}
	}
}
