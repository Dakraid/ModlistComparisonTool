// ModlistComparisonTool.Core - ColorPresetResources.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Windows;

using ModernWpf;
#endregion

namespace ModlistComparisonTool.Core.Presets;

public class ColorPresetResources : ResourceDictionary
{
	private ApplicationTheme _targetTheme;

	public ColorPresetResources()
	{
		WeakEventManager<PresetManager, EventArgs>.AddHandler(PresetManager.Current, nameof(PresetManager.ColorPresetChanged), OnCurrentPresetChanged);

		ApplyCurrentPreset();
	}

	public ApplicationTheme TargetTheme
	{
		get => _targetTheme;

		set
		{
			if (_targetTheme != value)
			{
				_targetTheme = value;
				ApplyCurrentPreset();
			}
		}
	}

	private void OnCurrentPresetChanged(object sender, EventArgs e)
	{
		ApplyCurrentPreset();
	}

	private void ApplyCurrentPreset()
	{
		if (MergedDictionaries.Count > 0)
		{
			MergedDictionaries.Clear();
		}

		var assemblyName = GetType().Assembly.GetName().Name;
		var currentPreset = PresetManager.Current.ColorPreset;
		var source = new Uri($"pack://application:,,,/{assemblyName};component/Presets/{currentPreset}/{TargetTheme}.xaml");
		var rd = new ResourceDictionary { Source = source };
		MergedDictionaries.Add(rd);
	}
}
