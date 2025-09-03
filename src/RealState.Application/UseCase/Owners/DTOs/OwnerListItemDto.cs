namespace RealState.Application.UseCase.Owners.DTOs;

public sealed record OwnerListItemDto(
    Guid Id,
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday,
    DateTime CreatedOn
);
