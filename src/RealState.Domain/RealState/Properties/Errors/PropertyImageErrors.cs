using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

/// <summary>
/// Contiene los errores de negocio específicos para la entidad <see cref="PropertyImage"/>.
/// </summary>
public static class PropertyImageErrors
{
    /// <summary>
    /// Error cuando no se encuentra la propiedad asociada al <paramref name="propertyId"/>.
    /// </summary>
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    /// <summary>
    /// Error cuando no se encuentra una imagen de propiedad por <paramref name="imageId"/>.
    /// </summary>
    public static Error PropertyImageNotFound(Guid imageId) => Error.NotFound(
        CodeResources.PropertyImageNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyImageNotFound_Id, imageId));

    /// <summary>
    /// Error de conflicto cuando ya existe una imagen con el mismo archivo.
    /// </summary>
    public static Error PropertyImageConflict(string file) => Error.Conflict(
        CodeResources.PropertyImageConflict,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyImageConflict_File, file));

    /// <summary>
    /// Error cuando los datos de la imagen de propiedad son inválidos.
    /// </summary>
    public static Error PropertyImageDataInvalid() => Error.Problem(
        CodeResources.PropertyImageDataInvalid,
        PropertiesResources.PropertyImageDataInvalid);

    /// <summary>
    /// Error cuando el archivo de la imagen es inválido (formato, tamaño, etc.).
    /// </summary>
    public static Error PropertyImageInvalid() => Error.Problem(
        CodeResources.PropertyImageInvalid,
        PropertiesResources.PropertyImageInvalid);

    /// <summary>
    /// Error cuando la carga de la imagen falla (problemas de almacenamiento o red).
    /// </summary>
    public static Error PropertyImageUploadFailed() => Error.Problem(
        CodeResources.PropertyImageUploadFailed,
        PropertiesResources.PropertyImageUploadFailed);
}