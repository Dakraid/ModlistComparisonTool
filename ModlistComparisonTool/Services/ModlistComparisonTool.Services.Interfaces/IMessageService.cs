// ModlistComparisonTool.Services.Interfaces - IMessageService.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 00:42

#region
using System.ComponentModel;
#endregion

namespace ModlistComparisonTool.Services.Interfaces;

public interface IMessageService : INotifyPropertyChanged
{
	void AddMessage(string message);
}
