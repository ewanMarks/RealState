using RealState.Application.Common.Messaging;

namespace RealState.Application.UseCase.PropertyImages.Commands;

public sealed record AddPropertyImageCommand(
    Guid IdProperty,
    string File,
    bool Enabled) : ICommand<Guid>;