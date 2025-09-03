namespace RealState.Contracts.Response.Properties.GetAll;

public sealed record PropertyListItemResponse(
    Guid Id,
    Guid IdOwner,
    string Name,
    string Address,
    decimal Price,
    string CodeInternal,
    int Year,
    DateTime CreatedOn);
