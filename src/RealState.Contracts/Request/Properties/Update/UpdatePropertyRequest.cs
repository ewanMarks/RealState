namespace RealState.Contracts.Request.Properties.Update;

public sealed record UpdatePropertyRequest(
    Guid Id,
    string Name,
    string Address,
    string CodeInternal,
    int Year);