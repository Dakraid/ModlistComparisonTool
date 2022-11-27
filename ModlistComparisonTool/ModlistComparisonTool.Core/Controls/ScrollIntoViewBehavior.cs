// ModlistComparisonTool.Core - ScrollIntoViewBehavior.cs
// Created on 2022.11.26
// Last modified at 2022.11.26 18:18

#region
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Controls;

using Microsoft.Xaml.Behaviors;
#endregion

namespace ModlistComparisonTool.Core.Controls;

public class ScrollIntoViewBehavior : Behavior<ListView>
{
	protected override void OnAttached()
	{
		var listBox = AssociatedObject;
		((INotifyCollectionChanged) listBox.Items).CollectionChanged += OnListBox_CollectionChanged;
	}

	protected override void OnDetaching()
	{
		var listBox = AssociatedObject;
		((INotifyCollectionChanged) listBox.Items).CollectionChanged -= OnListBox_CollectionChanged;
	}

	private void OnListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		var listBox = AssociatedObject;
		if (e.Action != NotifyCollectionChangedAction.Add)
		{
			return;
		}

		// scroll the new item into view
		try
		{
			listBox.ScrollIntoView(listBox.Items[^1]);
		}
		catch (Exception exception)
		{
			Debug.WriteLine(exception);
		}
	}
}
