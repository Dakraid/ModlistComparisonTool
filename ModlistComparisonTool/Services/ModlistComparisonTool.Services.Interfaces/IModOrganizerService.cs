// ModlistComparisonTool.Services.Interfaces - IModOrganizerService.cs
// Created on 2022.11.08
// Last modified at 2022.11.27 10:13

#region
using System.Threading.Tasks;

using ModlistComparisonTool.Core.Models;
#endregion

namespace ModlistComparisonTool.Services.Interfaces;

public interface IModOrganizerService
{
	public Task<ModOrganizerInstance> LoadInstance(string filePath);
	public Task ParseModlist(ModOrganizerInstance instance);
	public Task ParseMods(ModOrganizerInstance instance);
}
