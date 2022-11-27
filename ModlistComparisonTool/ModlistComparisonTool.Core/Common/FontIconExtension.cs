// ModlistComparisonTool.Core - FontIconExtension.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.Windows.Markup;

using ModernWpf.Controls;
#endregion

namespace ModlistComparisonTool.Core.Common;

[MarkupExtensionReturnType(typeof(FontIcon))]
public class FontIconExtension : MarkupExtension
{
	public FontIconExtension() {}

	public FontIconExtension(string glyph)
	{
		Glyph = glyph;
	}

	[ConstructorArgument("glyph")]
	public string Glyph { get; set; }

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return new FontIcon { Glyph = Glyph };
	}
}
