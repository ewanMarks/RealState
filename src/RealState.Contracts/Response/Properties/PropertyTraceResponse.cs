namespace RealState.Contracts.Response.Properties;

public sealed record PropertyTraceResponse(
    Guid Id,
    Guid IdProperty,
    DateTime DateSale,
    string? Name,
    decimal Value,
    decimal Tax);
