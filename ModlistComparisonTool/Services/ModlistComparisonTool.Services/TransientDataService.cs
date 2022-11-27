// ModlistComparisonTool.Services - TransientDataService.cs
// Created on 2022.11.18
// Last modified at 2022.11.26 01:31

#region
using System.ComponentModel;

using ModlistComparisonTool.Core.Models;
using ModlistComparisonTool.Services.Interfaces;
#endregion

namespace ModlistComparisonTool.Services;

public class TransientDataService : ITransientDataService
{
	public event PropertyChangedEventHandler PropertyChanged;
	public ModOrganizerInstance FirstOrganizerInstance { get; set; }
	public ModOrganizerInstance SecondOrganizerInstance { get; set; }
}
