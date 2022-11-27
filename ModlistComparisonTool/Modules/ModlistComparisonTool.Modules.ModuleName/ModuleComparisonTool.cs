// ModlistComparisonTool.Modules.ComparisonTool - ModuleComparisonTool.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using ModlistComparisonTool.Core;
using ModlistComparisonTool.Modules.ComparisonTool.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
#endregion

namespace ModlistComparisonTool.Modules.ComparisonTool;

public class ModuleComparisonTool : IModule
{
	private readonly IRegionManager _regionManager;

	public ModuleComparisonTool(IRegionManager regionManager)
	{
		_regionManager = regionManager;
	}

	public void OnInitialized(IContainerProvider containerProvider)
	{
		_regionManager.RequestNavigate(RegionNames.ContentRegion, "Start");
	}

	public void RegisterTypes(IContainerRegistry containerRegistry)
	{
		containerRegistry.RegisterForNavigation<ViewA>();
		containerRegistry.RegisterForNavigation<Start>();
	}
}
