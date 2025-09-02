namespace RealState.Contracts.Request.Owners.Create;

public sealed record CreateOwnerRequest(
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday);