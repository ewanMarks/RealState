namespace RealState.Contracts.Response.Properties;

public sealed record PropertyImageResponse(
    Guid Id,
    Guid IdProperty,
    string File,
    bool Enabled);