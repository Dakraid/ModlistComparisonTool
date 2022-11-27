// ModlistComparisonTool.Core - WindowExtensions.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System.Windows;
using System.Windows.Interop;
#endregion

namespace ModlistComparisonTool.Core.Common;

public static class WindowExtensions
{
	public static void SetPlacement(this Window window, string placementXml)
	{
		WindowPlacement.SetPlacement(new WindowInteropHelper(window).Handle, placementXml);
	}

	public static string GetPlacement(this Window window)
	{
		return WindowPlacement.GetPlacement(new WindowInteropHelper(window).Handle);
	}
}
