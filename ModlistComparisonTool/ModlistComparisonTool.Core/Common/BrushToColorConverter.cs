// ModlistComparisonTool.Core - BrushToColorConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class BrushToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is SolidColorBrush brush)
		{
			return brush.Color;
		}

		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is Color color)
		{
			return new SolidColorBrush(color);
		}

		return null;
	}
}
