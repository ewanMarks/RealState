using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Auth.DTOs;

namespace RealState.Application.UseCase.Auth.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<AuthResult>;