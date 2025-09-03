namespace RealState.Contracts.Response.Properties.GetAll;

public sealed record GetAllPropertiesResponse(
    IReadOnlyList<PropertyListItemResponse> Items,
    int Total,
    int Page,
    int PageSize);