// ModlistComparisonTool.Core - RegionViewModelBase.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;

using Prism.Regions;
#endregion

namespace ModlistComparisonTool.Core.Mvvm;

public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
{
	public RegionViewModelBase(IRegionManager regionManager)
	{
		RegionManager = regionManager;
	}

	protected IRegionManager RegionManager { get; }

	public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
	{
		continuationCallback(true);
	}

	public virtual bool IsNavigationTarget(NavigationContext navigationContext)
	{
		return true;
	}

	public virtual void OnNavigatedFrom(NavigationContext navigationContext) {}

	public virtual void OnNavigatedTo(NavigationContext navigationContext) {}
}
