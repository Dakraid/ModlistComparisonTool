// ModlistComparisonTool.Core - Extensions.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System.Windows;

using ModernWpf;
#endregion

namespace ModlistComparisonTool.Core.Common;

public static class Extensions
{
	public static void ToggleTheme(this FrameworkElement element)
	{
		ElementTheme newTheme;
		if (ThemeManager.GetActualTheme(element) == ElementTheme.Dark)
		{
			newTheme = ElementTheme.Light;
		}
		else
		{
			newTheme = ElementTheme.Dark;
		}

		ThemeManager.SetRequestedTheme(element, newTheme);
	}
}
