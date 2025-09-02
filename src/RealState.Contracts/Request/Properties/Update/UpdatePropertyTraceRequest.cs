namespace RealState.Contracts.Request.Properties.Update;

public sealed record UpdatePropertyTraceRequest(
    Guid Id,
    DateTime DateSale,
    string? Name,
    decimal Value,
    decimal Tax);