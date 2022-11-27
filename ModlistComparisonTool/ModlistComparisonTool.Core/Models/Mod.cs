// ModlistComparisonTool.Core - Mod.cs
// Created on 2022.11.08
// Last modified at 2022.11.26 01:31

#region
using System.ComponentModel;
#endregion

namespace ModlistComparisonTool.Core.Models;

public class Mod : INotifyPropertyChanged
{
	public string Name { get; set; }
	public string Path { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }

	public event PropertyChangedEventHandler PropertyChanged;
}
