// ModlistComparisonTool.Services - ModOrganizerService.cs
// Created on 2022.11.09
// Last modified at 2022.11.27 10:17

#region
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ModlistComparisonTool.Core.Models;
using ModlistComparisonTool.Services.Interfaces;
#endregion

namespace ModlistComparisonTool.Services;

public partial class ModOrganizerService : IModOrganizerService
{
	public ModOrganizerService(IMessageService messageService)
	{
		MessageService = messageService;
	}

	public IMessageService MessageService { get; }

	/// <inheritdoc />
	public async Task<ModOrganizerInstance> LoadInstance(string filePath)
	{
		if (!Directory.Exists(filePath))
		{
			throw new DirectoryNotFoundException("The entered directory does not exist.");
		}

		if (!File.Exists(Path.Join(filePath, "ModOrganizer.exe")))
		{
			throw new FileNotFoundException("Could not find ModOrganizer.exe.");
		}

		if (!Directory.Exists(Path.Join(filePath, "profiles")))
		{
			throw new DirectoryNotFoundException("Profile folder not found. Custom paths are not supported.");
		}

		var modOrganizerInstance = new ModOrganizerInstance { InstancePath = filePath };
		modOrganizerInstance.ProfileList.AddRange(Directory.EnumerateDirectories(Path.Join(filePath, "profiles")));
		modOrganizerInstance.HasProfile = true;

		var ini = await File.ReadAllLinesAsync(Path.Join(filePath, "ModOrganizer.ini"));

		var foundProfile = false;
		var foundGame = false;
		Parallel.ForEach(ini, (line, state) =>
		{
			if (line.Contains("selected_profile"))
			{
				var result = ByteArrayRegex().Match(line);

				if (result.Success)
				{
					modOrganizerInstance.ActiveListName = result.Groups[1].Value;
					foundProfile = true;
				}
			}
			else if (line.Contains("gamePath"))
			{
				var result = ByteArrayRegex().Match(line);

				if (result.Success)
				{
					modOrganizerInstance.IsLocal = !result.Groups[1].Value.Contains(@"steamapps\\common");
					foundGame = true;
				}
			}

			if (foundProfile && foundGame)
			{
				state.Break();
			}
		});

		return modOrganizerInstance;
	}

	/// <inheritdoc />
	public async Task ParseModlist(ModOrganizerInstance instance)
	{
		if (!File.Exists(Path.Join(instance.ActiveListName, "modlist.txt")))
		{
			throw new FileNotFoundException("Could not find the modlist.txt for the selected profile. Path: " + Path.Join(instance.ActiveListName, "modlist.txt"));
		}

		var modlist = (await File.ReadAllLinesAsync(Path.Join(instance.ActiveListName, "modlist.txt"))).ToList();

		var count = modlist.Count;
		MessageService.AddMessage("List has " + count + " items in '" + instance.ActiveListName + "'.");

		count = modlist.RemoveAll(s => s[0] == '-');
		MessageService.AddMessage("Detected " + count + " inactive items in '" + instance.ActiveListName + "'.");

		count = modlist.RemoveAll(s => s.Contains("_separator"));
		MessageService.AddMessage("Detected " + count + " separator items in '" + instance.ActiveListName + "'.");

		count = modlist.Count;
		MessageService.AddMessage("Reading " + count + " items left in '" + instance.ActiveListName + "'.");

		instance.ActiveListMods.AddRange(modlist);
	}

	/// <inheritdoc />
	public async Task ParseMods(ModOrganizerInstance instance)
	{
		Parallel.ForEachAsync(instance.ActiveListMods, async (line, ct) =>
		{
			if (!File.Exists(Path.Join(instance.InstancePath, "mods", line)))
			{
				throw new FileNotFoundException("Could not find the modlist.txt for the selected profile. Path: " + Path.Join(instance.ActiveListName, "modlist.txt"));
			}
		});
	}

	[GeneratedRegex("ByteArray\\((.*)\\)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
	private static partial Regex ByteArrayRegex();
}
