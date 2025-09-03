namespace RealState.Contracts.Response.Users.Login;

public sealed record AuthResponse(
    string AccessToken,
    DateTime ExpiresAtUtc,
    string TokenType = "Bearer");
