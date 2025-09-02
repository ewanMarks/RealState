namespace RealState.Contracts.Request.Properties.Create;

public sealed record CreatePropertyRequest(
    string Name,
    string? Address,
    decimal Price,
    string CodeInternal,
    int Year,
    Guid IdOwner);