using FluentAssertions;
using Moq;
using RealState.Application.UseCase.ChangePrice.Commands.Change;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Test.RealState.Properties;

public class ChangePropertyPriceCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_UpdatePrice_And_CreateTrace()
    {
        var propRepo = new Mock<IPropertyRepository>();
        var traceRepo = new Mock<IPropertyTraceRepository>();

        var property = new Property("N", "A", 1000m, "C1", 2020, Guid.NewGuid());
        propRepo.Setup(r => r.GetByIdAsync(property.Id, default)).ReturnsAsync(property);

        var handler = new ChangePropertyPriceCommandHandler(propRepo.Object, traceRepo.Object);
        var cmd = new ChangePropertyPriceCommand(property.Id, 1500m, "Change", 0);

        var result = await handler.Handle(cmd, default);

        result.IsSuccess.Should().BeTrue();
        propRepo.Verify(r => r.UpdateAsync(property), Times.Once);
        traceRepo.Verify(r => r.AddAsync(It.IsAny<PropertyTrace>(), default), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_Price_Invalid()
    {
        var propRepo = new Mock<IPropertyRepository>();
        var traceRepo = new Mock<IPropertyTraceRepository>();
        propRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), default)).ReturnsAsync(new Property("N", "A", 1000m, "C1", 2020, Guid.NewGuid()));

        var handler = new ChangePropertyPriceCommandHandler(propRepo.Object, traceRepo.Object);
        var cmd = new ChangePropertyPriceCommand(Guid.NewGuid(), 0m, null, null);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
        traceRepo.Verify(r => r.AddAsync(It.IsAny<PropertyTrace>(), default), Times.Never);
    }
}
