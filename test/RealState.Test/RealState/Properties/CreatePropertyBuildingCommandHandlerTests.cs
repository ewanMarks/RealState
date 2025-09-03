using FluentAssertions;
using Moq;
using RealState.Application.UseCase.Properties.Commands.Create;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using System.Linq.Expressions;

namespace RealState.Test.RealState.Properties;

public class CreatePropertyBuildingCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Create_When_OwnerExists_And_CodeUnique()
    {
        var propRepo = new Mock<IPropertyRepository>();
        var ownerRepo = new Mock<IOwnerRepository>();

        ownerRepo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Owner, bool>>>())).ReturnsAsync(true);
        propRepo.Setup(r => r.CodeInternalExistsAsync("X-1", default)).ReturnsAsync(false);

        var handler = new CreatePropertyBuildingCommandHandler(propRepo.Object, ownerRepo.Object);
        var cmd = new CreatePropertyBuildingCommand(Guid.NewGuid(), "Casa", "Dir", 1000m, "X-1", 2020);

        var result = await handler.Handle(cmd, default);

        result.IsSuccess.Should().BeTrue();
        propRepo.Verify(r => r.AddAsync(It.IsAny<Property>(), default), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_Owner_NotFound()
    {
        var propRepo = new Mock<IPropertyRepository>();
        var ownerRepo = new Mock<IOwnerRepository>();
        ownerRepo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Owner, bool>>>())).ReturnsAsync(false);

        var handler = new CreatePropertyBuildingCommandHandler(propRepo.Object, ownerRepo.Object);
        var cmd = new CreatePropertyBuildingCommand(Guid.NewGuid(), "Casa", "Dir", 1000m, "X-1", 2020);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
        propRepo.Verify(r => r.AddAsync(It.IsAny<Property>(), default), Times.Never);
    }
}
