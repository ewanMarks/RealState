using RealState.Application.Common.Messaging;
using RealState.Application.Common.Security;
using RealState.Application.UseCase.Auth.DTOs;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Users.Errors;
using RealState.Domain.RealState.Users.Repositories;

namespace RealState.Application.UseCase.Auth.Commands.Login;

/// <summary>
/// Handler del comando <see cref="LoginCommand"/> encargado de autenticar usuarios.
/// </summary
public sealed class LoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService)
    : ICommandHandler<LoginCommand, AuthResult>
{
    /// <summary>
    /// Maneja el comando de login y retorna un resultado con un JWT si las credenciales son válidas.
    /// </summary>
    public async Task<Result<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<AuthResult>(UserErrors.InvalidCredentials());
        }

        if (!user.IsActive)
        {
            return Result.Failure<AuthResult>(UserErrors.UserInactive(user.Email));
        }

        bool ok = passwordHasher.Verify(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!ok)
        {
            return Result.Failure<AuthResult>(UserErrors.InvalidCredentials());
        }
        
        var (token, expiresAt) = jwtTokenService.Generate(user.Id, user.Email, user.Role);

        var auth = new AuthResult(token, expiresAt);
        return auth;
    }
}