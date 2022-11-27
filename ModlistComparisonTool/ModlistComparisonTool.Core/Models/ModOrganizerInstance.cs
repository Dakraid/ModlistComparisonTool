// ModlistComparisonTool.Core - ModOrganizerInstance.cs
// Created on 2022.11.08
// Last modified at 2022.11.26 00:50

#region
using System.Collections.ObjectModel;
using System.ComponentModel;
#endregion

namespace ModlistComparisonTool.Core.Models;

public class ModOrganizerInstance : INotifyPropertyChanged
{
	public string InstancePath { get; set; }
	public bool IsLocal { get; set; }
	public ObservableCollection<string> ProfileList { get; set; } = new();
	public bool HasProfile { get; set; }
	public string ActiveListName { get; set; }
	public ObservableCollection<string> ActiveListMods { get; set; } = new();
	public ObservableCollection<Mod> ActiveMods { get; set; } = new();

	public event PropertyChangedEventHandler PropertyChanged;
}
