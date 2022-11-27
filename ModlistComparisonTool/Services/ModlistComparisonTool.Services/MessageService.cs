// ModlistComparisonTool.Services - MessageService.cs
// Created on 2022.11.07
// Last modified at 2022.11.27 10:12

#region
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;

using ModlistComparisonTool.Services.Interfaces;
#endregion

namespace ModlistComparisonTool.Services;

public class MessageService : IMessageService
{
	public ObservableCollection<string> Messages { get; set; } = new();

	public string CurrentMessage { get; set; }

	/// <inheritdoc />
	public event PropertyChangedEventHandler PropertyChanged;

	/// <inheritdoc />
	public void AddMessage(string message)
	{
		var timestampedMessage = DateTime.Now.ToString("[dd.mm.yyyy HH:mm:ss] ") + message;
		CurrentMessage = timestampedMessage;
		Thread.Sleep(50);
		Messages.Add(timestampedMessage);
	}
}
