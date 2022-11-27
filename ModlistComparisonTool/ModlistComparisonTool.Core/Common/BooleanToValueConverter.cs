// ModlistComparisonTool.Core - BooleanToValueConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;
#endregion

namespace ModlistComparisonTool.Core.Common;

public sealed class BooleanToValueConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool) value ? parameter : null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
