namespace RealState.Contracts.Request.Properties.Update;

public sealed record UpdatePropertyImageRequest(
    Guid Id,
    string File,
    bool Enabled);