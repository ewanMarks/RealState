namespace RealState.Contracts.Response.Properties;

public sealed record PropertyResponse(
    Guid Id,
    string Name,
    string? Address,
    decimal Price,
    string CodeInternal,
    int Year,
    Guid IdOwner);