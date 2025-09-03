using FluentAssertions;
using Moq;
using RealState.Application.Common.Security;
using RealState.Application.UseCase.Auth.Commands.Login;
using RealState.Domain.RealState.Users.Entities;
using RealState.Domain.RealState.Users.Repositories;

namespace RealState.Test.RealState.Users;

public class LoginCommandHandlerTests
{
    [Test]
    public async Task Handle_Should_Return_Token_When_Credentials_Are_Valid()
    {
        var userRepo = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher>();
        var jwt = new Mock<IJwtTokenService>();

        var user = new User("admin@realstate.com", "hash", "salt", "Admin");
        userRepo.Setup(r => r.GetByEmailAsync(user.Email, default)).ReturnsAsync(user);
        hasher.Setup(h => h.Verify("pwd", "hash", "salt")).Returns(true);
        jwt.Setup(j => j.Generate(user.Id, user.Email, user.Role)).Returns(("token", DateTime.UtcNow.AddMinutes(60)));

        var handler = new LoginCommandHandler(userRepo.Object, hasher.Object, jwt.Object);
        var result = await handler.Handle(new LoginCommand(user.Email, "pwd"), default);

        result.IsSuccess.Should().BeTrue();
        result.Value.AccessToken.Should().Be("token");
    }

    [Test]
    public async Task Handle_Should_Fail_When_Password_Invalid()
    {
        var userRepo = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher>();
        var jwt = new Mock<IJwtTokenService>();

        var user = new User("admin@realstate.com", "hash", "salt", "Admin");
        userRepo.Setup(r => r.GetByEmailAsync(user.Email, default)).ReturnsAsync(user);
        hasher.Setup(h => h.Verify("bad", "hash", "salt")).Returns(false);

        var handler = new LoginCommandHandler(userRepo.Object, hasher.Object, jwt.Object);
        var result = await handler.Handle(new LoginCommand(user.Email, "bad"), default);

        result.IsFailure.Should().BeTrue();
        jwt.Verify(j => j.Generate(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }
}