// ModlistComparisonTool - MainWindowViewModel.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using Prism.Mvvm;
#endregion

namespace ModlistComparisonTool.ViewModels;

public class MainWindowViewModel : BindableBase
{
	private string _title = "Modlist Comparison Tool (MolCaT)";

	public string Title { get => _title; set => SetProperty(ref _title, value); }
}
