using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Owners.Commands.Desactivate;

public sealed record DeactivateOwnerCommand(Guid Id) : ICommand<Guid>;