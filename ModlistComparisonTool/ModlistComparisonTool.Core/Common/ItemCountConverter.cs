// ModlistComparisonTool.Core - ItemCountConverter.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Globalization;
using System.Windows.Data;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class ItemCountConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is int count)
		{
			if (count > 1)
			{
				return $"({count} items)";
			}

			if (count == 1)
			{
				return $"({count} item)";
			}
		}

		return string.Empty;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
