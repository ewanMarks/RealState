using Microsoft.AspNetCore.Http;

namespace RealState.Contracts.Request.Properties.AddImage;

public sealed record UploadPropertyImageRequest(
    Guid IdProperty,
    IFormFile File,
    bool Enabled);