namespace RealState.Contracts.Request.Properties.AddImage;

public sealed record AddPropertyImageRequest(
    Guid IdProperty,
    string File,
    bool Enabled);