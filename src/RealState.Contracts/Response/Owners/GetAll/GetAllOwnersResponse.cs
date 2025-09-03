namespace RealState.Contracts.Response.Owners.GetAll;

public sealed record GetAllOwnersResponse(
    IReadOnlyList<OwnerListItemResponse> Items,
    int Total,
    int Page,
    int PageSize);