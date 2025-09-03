using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Properties.Commands.Create;

public sealed record CreatePropertyBuildingCommand(
    Guid IdOwner,
    string Name,
    string Address,
    decimal Price,
    string CodeInternal,
    int Year
) : ICommand<Guid>;