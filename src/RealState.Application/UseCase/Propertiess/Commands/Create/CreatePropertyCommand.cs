using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.Propertiess.Commands.Create;

public sealed record CreatePropertyCommand(
    string Name,
    string? Address,
    decimal Price,
    string CodeInternal,
    int Year,
    Guid IdOwner
) : ICommand<Guid>;