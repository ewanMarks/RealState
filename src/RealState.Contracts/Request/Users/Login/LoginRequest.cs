namespace RealState.Contracts.Request.Users.Login;

public sealed record LoginRequest(
    string Email,
    string Password);