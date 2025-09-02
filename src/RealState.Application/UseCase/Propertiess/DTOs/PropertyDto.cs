namespace RealState.Application.UseCase.Propertiess.DTOs;

public sealed record PropertyDto(Guid Id, string Name, string? Address, decimal Price, string CodeInternal, int Year, Guid IdOwner);