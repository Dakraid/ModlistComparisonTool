// ModlistComparisonTool.Services.Interfaces - ITransientDataService.cs
// Created on 2022.11.18
// Last modified at 2022.11.26 01:31

#region
#endregion

#region
using System.ComponentModel;

using ModlistComparisonTool.Core.Models;
#endregion

namespace ModlistComparisonTool.Services.Interfaces;

public interface ITransientDataService : INotifyPropertyChanged
{
	public ModOrganizerInstance FirstOrganizerInstance { get; set; }

	public ModOrganizerInstance SecondOrganizerInstance { get; set; }
}
