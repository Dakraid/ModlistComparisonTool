// ModlistComparisonTool.Core - Category.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using ModernWpf.Controls;
#endregion

namespace ModlistComparisonTool.Core.Common;

public class CategoryBase {}

public class Category : CategoryBase
{
	public string Name { get; set; }
	public string Tooltip { get; set; }

	public Symbol Glyph { get; set; }
	//public Type TargetType { get; set; }
}

public class Separator : CategoryBase {}

public class Header : CategoryBase
{
	public string Name { get; set; }
}
