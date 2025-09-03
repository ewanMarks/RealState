namespace RealState.Contracts.Response.Owners.GetAll;

public sealed record OwnerListItemResponse(
    Guid Id,
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday,
    DateTime CreatedOn);