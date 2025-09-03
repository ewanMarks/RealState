using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.ChangePrice.Commands.Change;

public sealed record ChangePropertyPriceCommand(
    Guid IdProperty,
    decimal NewPrice,
    string? Name,
    decimal? Tax) : ICommand<Guid>;