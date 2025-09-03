namespace RealState.Application.UseCase.Properties.DTOs;

public sealed record GetAllPropertiesResult(
    IReadOnlyList<PropertyListItemDto> Items,
    int Total,
    int Page,
    int PageSize
);