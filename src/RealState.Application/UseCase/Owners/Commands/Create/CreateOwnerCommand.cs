using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Owners.Commands.Create;

public sealed record CreateOwnerCommand(
    string Name,
    string? Address,
    string? Photo,
    DateOnly? Birthday) : ICommand<Guid>;
