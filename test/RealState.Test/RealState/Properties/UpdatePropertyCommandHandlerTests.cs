using FluentAssertions;
using Moq;
using RealState.Application.UseCase.Properties.Commands.Update;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Test.RealState.Properties;

public class UpdatePropertyCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Update_When_Exists_And_CodeUnique()
    {
        var repo = new Mock<IPropertyRepository>();
        var prop = new Property("N", "A", 1000m, "C1", 2020, Guid.NewGuid());

        repo.Setup(r => r.GetByIdAsync(prop.Id, default)).ReturnsAsync(prop);
        repo.Setup(r => r.CodeInternalExistsForOtherAsync(prop.Id, "C1", default)).ReturnsAsync(false);

        var handler = new UpdatePropertyCommandHandler(repo.Object);
        var cmd = new UpdatePropertyCommand(prop.Id, "N2", "A2", "C1", 2021);

        var result = await handler.Handle(cmd, default);

        result.IsSuccess.Should().BeTrue();
        repo.Verify(r => r.UpdateAsync(prop), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_NotFound()
    {
        var repo = new Mock<IPropertyRepository>();
        repo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), default)).ReturnsAsync((Property?)null);

        var handler = new UpdatePropertyCommandHandler(repo.Object);
        var cmd = new UpdatePropertyCommand(Guid.NewGuid(), "N2", "A2", "C1", 2021);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
    }
}