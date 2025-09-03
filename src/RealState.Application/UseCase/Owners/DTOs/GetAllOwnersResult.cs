namespace RealState.Application.UseCase.Owners.DTOs;

public sealed record GetAllOwnersResult(
    IReadOnlyList<OwnerListItemDto> Items,
    int Total,
    int Page,
    int PageSize
);
