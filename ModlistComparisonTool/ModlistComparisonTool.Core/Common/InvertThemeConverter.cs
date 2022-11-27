// ModlistComparisonTool.Core - InvertThemeConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;

using ModernWpf;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class InvertThemeConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		var theme = (ElementTheme) value;
		switch (theme)
		{
		case ElementTheme.Light:
			return ElementTheme.Dark;

		case ElementTheme.Dark:
			return ElementTheme.Light;

		default:
			return theme;
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
