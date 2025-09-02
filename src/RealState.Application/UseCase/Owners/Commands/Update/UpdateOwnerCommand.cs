using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Owners.Commands.Update;

public sealed record UpdateOwnerCommand(
    Guid Id,
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday) : ICommand<Guid>;