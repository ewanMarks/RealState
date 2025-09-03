using FluentAssertions;
using Moq;
using RealState.Application.UseCase.Owners.Commands.Create;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Repositories;
using System.Linq.Expressions;

namespace RealState.Test.RealState.Owners;

public class CreateOwnerCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Create_Owner_When_Name_Is_Unique()
    {
        // Arrange
        var repo = new Mock<IOwnerRepository>();
        repo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Owner, bool>>>())).ReturnsAsync(false);

        var handler = new CreateOwnerCommandHandler(repo.Object);
        var cmd = new CreateOwnerCommand("Lina", "Av. 07", null, new DateOnly(1990, 1, 1));

        // Act
        Result<Guid> result = await handler.Handle(cmd, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        repo.Verify(r => r.AddAsync(It.IsAny<Owner>(), default), Times.Once);
    }

    [Test]
    public async Task Handle_Should_Fail_When_Name_Already_Exists()
    {
        var repo = new Mock<IOwnerRepository>();
        repo.Setup(r => r.ExistsAsync(It.IsAny<Expression<Func<Owner, bool>>>())).ReturnsAsync(true);

        var handler = new CreateOwnerCommandHandler(repo.Object);
        var cmd = new CreateOwnerCommand("Lina", null, null, null);

        var result = await handler.Handle(cmd, default);

        result.IsFailure.Should().BeTrue();
        repo.Verify(r => r.AddAsync(It.IsAny<Owner>(), default), Times.Never);
    }
}