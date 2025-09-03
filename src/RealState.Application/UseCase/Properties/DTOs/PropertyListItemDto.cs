namespace RealState.Application.UseCase.Properties.DTOs;

public sealed record PropertyListItemDto(
    Guid Id,
    Guid IdOwner,
    string Name,
    string Address,
    decimal Price,
    string CodeInternal,
    int Year,
    DateTime CreatedOn
);
