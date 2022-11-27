// ModlistComparisonTool.Core - ViewModelBase.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using Prism.Mvvm;
using Prism.Navigation;
#endregion

namespace ModlistComparisonTool.Core.Mvvm;

public abstract class ViewModelBase : BindableBase, IDestructible
{
	public virtual void Destroy() {}
}
