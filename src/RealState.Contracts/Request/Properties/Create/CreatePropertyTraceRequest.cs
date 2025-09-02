namespace RealState.Contracts.Request.Properties.Create;

public sealed record CreatePropertyTraceRequest(
    Guid IdProperty,
    DateTime DateSale,
    string? Name,
    decimal Value,
    decimal Tax);