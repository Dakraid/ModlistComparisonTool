// ModlistComparisonTool.Modules.ComparisonTool - StartViewModel.cs
// Created on 2022.11.08
// Last modified at 2022.11.26 01:24

#region
using System;
using System.Windows;

using ModlistComparisonTool.Core.Mvvm;
using ModlistComparisonTool.Services.Interfaces;

using Ookii.Dialogs.Wpf;

using Prism.Commands;
using Prism.Regions;
#endregion

namespace ModlistComparisonTool.Modules.ComparisonTool.ViewModels;

public class StartViewModel : RegionViewModelBase
{
	public StartViewModel(IRegionManager regionManager, ITransientDataService transientDataService, IModOrganizerService modOrganizerService, IMessageService messageService) : base(regionManager)
	{
		SelectFirstPathCommand = new DelegateCommand(SelectFirstPath);
		SelectSecondPathCommand = new DelegateCommand(SelectSecondPath);
		ProcessCommand = new DelegateCommand(Process);
		MessageService = messageService;
		DataService = transientDataService;
		OrganizerService = modOrganizerService;
	}

	public bool IsProcessing { get; set; }
	public bool FirstSelected { get; set; }
	public bool SecondSelected { get; set; }
	public bool ProcessActive => FirstSelected && SecondSelected;

	public IMessageService MessageService { get; }
	public ITransientDataService DataService { get; }
	public IModOrganizerService OrganizerService { get; }

	public DelegateCommand SelectFirstPathCommand { get; }
	public DelegateCommand SelectSecondPathCommand { get; }
	public DelegateCommand ProcessCommand { get; }

	public override void OnNavigatedTo(NavigationContext navigationContext)
	{
		//do something
	}

	public async void SelectFirstPath()
	{
		var dialog = new VistaFolderBrowserDialog { Description = "Please select the Mod Organizer folder.", UseDescriptionForTitle = true };

		var result = dialog.ShowDialog();

		if (!result.HasValue || !result.Value)
		{
			// MessageBox.Show("Invalid folder selected, please try again.", "Error");
			return;
		}

		try
		{
			DataService.FirstOrganizerInstance = await OrganizerService.LoadInstance(dialog.SelectedPath);
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		FirstSelected = true;
	}

	public async void SelectSecondPath()
	{
		var dialog = new VistaFolderBrowserDialog { Description = "Please select the Mod Organizer folder.", UseDescriptionForTitle = true };

		var result = dialog.ShowDialog();

		if (!result.HasValue || !result.Value)
		{
			// MessageBox.Show("Invalid folder selected, please try again.", "Error");
			return;
		}

		try
		{
			DataService.SecondOrganizerInstance = await OrganizerService.LoadInstance(dialog.SelectedPath);
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		SecondSelected = true;
	}

	public async void Process()
	{
		if (!ProcessActive)
		{
			return;
		}

		IsProcessing = true;
		MessageService.AddMessage("Initializing modlist reader...");

		MessageService.AddMessage("Parsing first modlist...");
		await OrganizerService.ParseModlist(DataService.FirstOrganizerInstance);

		MessageService.AddMessage("Parsing second modlist...");
		await OrganizerService.ParseModlist(DataService.SecondOrganizerInstance);

		MessageService.AddMessage("Reading mods from first instance...");
		// Do Stuff

		IsProcessing = false;
	}
}
