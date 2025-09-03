namespace RealState.Application.UseCase.Auth.DTOs;

public sealed record AuthResult(
    string AccessToken,
    DateTime ExpiresAtUtc,
    string TokenType = "Bearer");