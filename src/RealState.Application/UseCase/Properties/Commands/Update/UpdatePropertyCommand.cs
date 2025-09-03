using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Properties.Commands.Update;

public sealed record UpdatePropertyCommand(
    Guid Id,
    string Name,
    string Address,
    string CodeInternal,
    int Year) : ICommand<Guid>;