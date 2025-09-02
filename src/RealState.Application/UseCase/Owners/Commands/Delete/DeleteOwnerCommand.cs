using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Owners.Commands.Delete;

public sealed record DeleteOwnerCommand(Guid Id) : ICommand<Guid>;