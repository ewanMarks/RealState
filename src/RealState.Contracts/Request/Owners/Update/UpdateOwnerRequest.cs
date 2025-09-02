namespace RealState.Contracts.Request.Owners.Update;

public sealed record UpdateOwnerRequest(
    Guid Id,
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday);
