namespace RealState.Contracts.Request.Properties.Create;

public sealed record CreatePropertyImageRequest(
    Guid IdProperty,
    string File,
    bool Enabled);