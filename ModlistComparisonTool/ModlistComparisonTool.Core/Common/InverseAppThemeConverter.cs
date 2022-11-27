// ModlistComparisonTool.Core - InverseAppThemeConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;

using ModernWpf;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class InverseAppThemeConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		switch ((ApplicationTheme) value)
		{
		case ApplicationTheme.Light:
			return ElementTheme.Dark;

		case ApplicationTheme.Dark:
			return ElementTheme.Light;

		default:
			throw new ArgumentOutOfRangeException(nameof(value));
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
