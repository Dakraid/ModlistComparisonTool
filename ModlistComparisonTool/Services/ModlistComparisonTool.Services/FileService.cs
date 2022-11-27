// ModlistComparisonTool.Services - FileService.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using ModlistComparisonTool.Services.Interfaces;
#endregion

namespace ModlistComparisonTool.Services;

public class FileService : IFileService
{
	/// <inheritdoc />
	public async Task<FileInfo> LoadFile(string filePath)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public async Task<HashSet<FileInfo>> LoadFiles(List<string> filePath)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public async Task<FileInfo[]> LoadFilesOrdered(string[] filePath)
	{
		throw new NotImplementedException();
	}
}
