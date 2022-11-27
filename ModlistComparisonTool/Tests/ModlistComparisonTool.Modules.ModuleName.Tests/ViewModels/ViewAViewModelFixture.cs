// ModlistComparisonTool.Modules.ModuleName.Tests - ViewAViewModelFixture.cs
// Created on 2022.11.07
// Last modified at 2022.11.09 00:12

#region
using ModlistComparisonTool.Modules.ComparisonTool.ViewModels;
using ModlistComparisonTool.Services.Interfaces;

using Moq;

using Prism.Regions;

using Xunit;
#endregion

namespace ModlistComparisonTool.Modules.ModuleName.Tests.ViewModels;

public class ViewAViewModelFixture
{
	private const string MessageServiceDefaultMessage = "Some Value";
	private readonly Mock<IMessageService> _messageServiceMock;
	private readonly Mock<IRegionManager> _regionManagerMock;

	public ViewAViewModelFixture()
	{
		var messageService = new Mock<IMessageService>();
		messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
		_messageServiceMock = messageService;

		_regionManagerMock = new Mock<IRegionManager>();
	}

	[Fact]
	public void MessagePropertyValueUpdated()
	{
		var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

		_messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

		Assert.Equal(MessageServiceDefaultMessage, vm.Message);
	}

	[Fact]
	public void MessageINotifyPropertyChangedCalled()
	{
		var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);
		Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
	}
}
