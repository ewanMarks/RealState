namespace RealState.Application.UseCase.Owners.DTOs;

public sealed record OwnerDto(Guid Id, string Name, string? Address, string? Photo, DateOnly? Birthday);