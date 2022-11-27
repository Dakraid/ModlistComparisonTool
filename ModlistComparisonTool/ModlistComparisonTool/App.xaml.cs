// ModlistComparisonTool - App.xaml.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System.Windows;

using ModlistComparisonTool.Modules.ComparisonTool;
using ModlistComparisonTool.Services;
using ModlistComparisonTool.Services.Interfaces;
using ModlistComparisonTool.Views;

using Prism.Ioc;
using Prism.Modularity;
#endregion

namespace ModlistComparisonTool;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App
{
	protected override Window CreateShell()
	{
		return Container.Resolve<MainWindow>();
	}

	protected override void RegisterTypes(IContainerRegistry containerRegistry)
	{
		containerRegistry.RegisterSingleton<IMessageService, MessageService>();
		containerRegistry.RegisterSingleton<IModOrganizerService, ModOrganizerService>();
		containerRegistry.RegisterSingleton<ITransientDataService, TransientDataService>();
	}

	protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
	{
		moduleCatalog.AddModule<ModuleComparisonTool>();
	}
}
