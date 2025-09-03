using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

public static class PropertyImageErrors
{
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    public static Error PropertyImageNotFound(Guid imageId) => Error.NotFound(
        CodeResources.PropertyImageNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyImageNotFound_Id, imageId));

    public static Error PropertyImageConflict(string file) => Error.Conflict(
        CodeResources.PropertyImageConflict,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyImageConflict_File, file));

    public static Error PropertyImageDataInvalid() => Error.Problem(
        CodeResources.PropertyImageDataInvalid,
        PropertiesResources.PropertyImageDataInvalid);

    public static Error PropertyImageInvalid() => Error.Problem(
        CodeResources.PropertyImageInvalid,
        PropertiesResources.PropertyImageInvalid);

    public static Error PropertyImageUploadFailed() => Error.Problem(
        CodeResources.PropertyImageUploadFailed,
        PropertiesResources.PropertyImageUploadFailed);
}