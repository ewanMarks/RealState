using FluentAssertions;
using Moq;
using RealState.Application.UseCase.PropertyImages.Commands;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using System.Linq.Expressions;

namespace RealState.Test.RealState.Properties;

public class AddPropertyImageCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Create_When_PropertyExists_And_NotDuplicate()
    {
        var imgRepo = new Mock<IPropertyImageRepository>();
        var propRepo = new Mock<IPropertyRepository>();

        propRepo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Property, bool>>>())).ReturnsAsync(true);
        imgRepo.Setup(r => r.ExistsSameFileAsync(It.IsAny<Guid>(), "path.jpg", default)).ReturnsAsync(false);

        var handler = new AddPropertyImageCommandHandler(imgRepo.Object, propRepo.Object);
        var cmd = new AddPropertyImageCommand(Guid.NewGuid(), "path.jpg", true);

        var result = await handler.Handle(cmd, default);

        result.IsSuccess.Should().BeTrue();
        imgRepo.Verify(r => r.AddAsync(It.IsAny<PropertyImage>(), default), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_Duplicate_File()
    {
        var imgRepo = new Mock<IPropertyImageRepository>();
        var propRepo = new Mock<IPropertyRepository>();

        propRepo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Property, bool>>>())).ReturnsAsync(true);
        imgRepo.Setup(r => r.ExistsSameFileAsync(It.IsAny<Guid>(), "path.jpg", default)).ReturnsAsync(true);

        var handler = new AddPropertyImageCommandHandler(imgRepo.Object, propRepo.Object);
        var cmd = new AddPropertyImageCommand(Guid.NewGuid(), "path.jpg", true);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
        imgRepo.Verify(r => r.AddAsync(It.IsAny<PropertyImage>(), default), Times.Never);
    }
}
