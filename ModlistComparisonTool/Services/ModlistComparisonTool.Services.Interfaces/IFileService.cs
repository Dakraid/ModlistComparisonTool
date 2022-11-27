// ModlistComparisonTool.Services.Interfaces - IFileService.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
#endregion

namespace ModlistComparisonTool.Services.Interfaces;

public interface IFileService
{
	Task<FileInfo> LoadFile(string filePath);

	Task<HashSet<FileInfo>> LoadFiles(List<string> filePath);

	Task<FileInfo[]> LoadFilesOrdered(string[] filePath);
}
