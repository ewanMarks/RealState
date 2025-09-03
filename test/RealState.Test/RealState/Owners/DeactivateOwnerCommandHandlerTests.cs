using FluentAssertions;
using Moq;
using RealState.Application.UseCase.Owners.Commands.Deactivate;
using RealState.Application.UseCase.Owners.Commands.Desactivate;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Test.RealState.Owners;

public class DeactivateOwnerCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Deactivate_When_NoLinkedProperties()
    {
        var repo = new Mock<IOwnerRepository>();
        var owner = new Owner("Ana", null, null, null);

        repo.Setup(r => r.GetByIdAsync(owner.Id, default)).ReturnsAsync(owner);
        repo.Setup(r => r.HasLinkedPropertiesAsync(owner.Id, default)).ReturnsAsync(false);

        var handler = new DeactivateOwnerCommandHandler(repo.Object);
        var cmd = new DeactivateOwnerCommand(owner.Id);

        var result = await handler.Handle(cmd, default);

        result.IsSuccess.Should().BeTrue();
        owner.IsActive.Should().BeFalse();
        repo.Verify(r => r.UpdateAsync(owner), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_HasLinkedProperties()
    {
        var repo = new Mock<IOwnerRepository>();
        var owner = new Owner("Ana", null, null, null);

        repo.Setup(r => r.GetByIdAsync(owner.Id, default)).ReturnsAsync(owner);
        repo.Setup(r => r.HasLinkedPropertiesAsync(owner.Id, default)).ReturnsAsync(true);

        var handler = new DeactivateOwnerCommandHandler(repo.Object);
        var cmd = new DeactivateOwnerCommand(owner.Id);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
        owner.IsActive.Should().BeTrue();
        repo.Verify(r => r.UpdateAsync(owner), Times.Never);
    }
}