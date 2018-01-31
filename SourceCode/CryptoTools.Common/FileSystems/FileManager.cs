﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTools.Common.FileSystems
{
	/// <summary>
	/// Wrapper / Facade class to the file system. this provides a higher level interface to the core .NET Api for managing files.
	/// </summary>
	public class FileManager
	{
		public void DeleteFolder(string folderName, bool recursive = false)
		{
			try
			{
				if (Directory.Exists(folderName))
				{
					Directory.Delete(folderName, recursive);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}

		public void DeleteAllFilesAndDirectories(List<string> files, List<string> directories, bool recursiveDirectories = false)
		{
			try
			{
				// Remove files first
				foreach (string fileName in files)
				{

					try
					{
						File.Delete(fileName);
					}
					catch (Exception exception)
					{
						Debug.WriteLine(exception.Message);
					}
				}

				// Now the directories
				foreach (string directoryName in directories)
				{
					try
					{
						Directory.Delete(directoryName, recursiveDirectories);
					}
					catch (Exception exception)
					{
						Debug.WriteLine(exception.Message);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.WriteLine(exception.Message);
			}
		}

		public void DeleteFile(string fileName)
		{
			try
			{
				File.Delete(fileName);

			}
			catch (Exception)
			{
				throw;
			}

			File.Delete(fileName);
		}

		public FileInfo GetFileInfo(string fileName)
		{
			FileInfo info = new FileInfo(fileName);
			return info;
		}

		

		public void CreateWriteBytes(string fullFileName, byte[] bytes)
		{
			File.WriteAllBytes(fullFileName, bytes);
		}

		public bool DirectoryExists(string directoryRoot)
		{
			return Directory.Exists(directoryRoot);
		}

		public bool FileExists(string archiveFileName)
		{
			return File.Exists(archiveFileName);
		}
	}
}
