// ModlistComparisonTool.Core - SolidColorBrushToColorStringConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class SolidColorBrushToColorStringConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is SolidColorBrush brush)
		{
			var color = brush.Color;
			if (brush.Opacity != 1)
			{
				Debug.Assert(color.A == 255);
				color = Color.FromArgb((byte) (color.A * brush.Opacity), color.R, color.G, color.B);
			}

			return color.ToString();
		}

		return string.Empty;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
