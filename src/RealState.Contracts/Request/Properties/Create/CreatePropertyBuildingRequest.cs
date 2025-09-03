namespace RealState.Contracts.Request.Properties.Create;

public sealed record CreatePropertyBuildingRequest(
    string Name,
    string Address,
    decimal Price,
    string CodeInternal,
    int Year,
    Guid IdOwner);