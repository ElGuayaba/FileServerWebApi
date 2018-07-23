using FileServer.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using FileServer.Common.Layer.Resources;
using System.Configuration;

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
			FileName = Properties.Settings.Default.FileName;
			FilePath = Properties.Settings.Default.FilePath + FileName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FileManager"/> class.
		/// </summary>
		public FileManager(string filename)
		{
			FileName = filename;
			FilePath = Properties.Settings.Default.FilePath + FileName;
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
					LogManager.LogError();
					throw new VuelingException(FMResources.Unauthorized, ex);
				}
				catch (ArgumentNullException ex)
				{
					LogManager.LogError();
					throw new VuelingException(FMResources.ArgumentNull, ex);
				}
				catch (ArgumentException ex)
				{
					LogManager.LogError();
					throw new VuelingException(FMResources.Argument, ex);
				}
				catch (DirectoryNotFoundException ex)
				{
					LogManager.LogError();
					throw new VuelingException(FMResources.NotFound, ex);
				}
				catch (PathTooLongException ex)
				{
					LogManager.LogError();
					throw new VuelingException(FMResources.PathTooLong, ex);
				}
				catch (IOException ex)
				{
					LogManager.LogError();
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
				LogManager.LogError();
				throw new VuelingException(FMResources.Unauthorized, ex);
			}
			catch (ArgumentNullException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.ArgumentNull, ex);
			}
			catch (ArgumentException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.Argument, ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.NotFound, ex);
			}
			catch (PathTooLongException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.PathTooLong, ex);
			}
			catch (IOException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.IO, ex);
			}
			catch (NotSupportedException ex)
			{
				LogManager.LogError();
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
				LogManager.LogError();
				throw new VuelingException(FMResources.Unauthorized, ex);
			}
			catch (ArgumentNullException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.ArgumentNull, ex);
			}
			catch (ArgumentException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.Argument, ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.NotFound, ex);
			}
			catch (PathTooLongException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.PathTooLong, ex);
			}
			catch (IOException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.IO, ex);
			}
			catch (NotSupportedException ex)
			{
				LogManager.LogError();
				throw new VuelingException(FMResources.NotSupported, ex);
			}
		}
	}
}
