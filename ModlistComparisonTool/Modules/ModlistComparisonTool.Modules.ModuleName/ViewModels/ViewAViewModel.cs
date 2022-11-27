// ModlistComparisonTool.Modules.ComparisonTool - ViewAViewModel.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using ModlistComparisonTool.Core.Mvvm;
using ModlistComparisonTool.Services.Interfaces;

using Prism.Regions;
#endregion

namespace ModlistComparisonTool.Modules.ComparisonTool.ViewModels;

public class ViewAViewModel : RegionViewModelBase
{
	private string _message;

	public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) : base(regionManager) {}

	public string Message { get => _message; set => SetProperty(ref _message, value); }

	public override void OnNavigatedTo(NavigationContext navigationContext)
	{
		//do something
	}
}
