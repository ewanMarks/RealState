namespace RealState.Contracts.Request.Properties.ChangePrice;

public sealed record ChangePropertyPriceRequest(
    Guid IdProperty,
    decimal NewPrice,
    string? Name,
    decimal? Tax
);