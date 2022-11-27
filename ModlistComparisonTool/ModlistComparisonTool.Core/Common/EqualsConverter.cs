// ModlistComparisonTool.Core - EqualsConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class EqualsConverter : IValueConverter
{
	public object Value { get; set; }

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return Equals(value, Value);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
