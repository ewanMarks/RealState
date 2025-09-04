using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

/// <summary>
/// Contiene los errores de negocio específicos para la entidad <see cref="Property"/>.
/// </summary>
public static class PropertyErrors
{
    /// <summary>
    /// Error cuando no se encuentra un propietario asociado a la propiedad.
    /// </summary>
    public static Error OwnerNotFound(Guid ownerId) => Error.NotFound(
        CodeResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.OwnerNotFound_Id, ownerId));

    /// <summary>
    /// Error cuando no se encuentra una propiedad por <paramref name="propertyId"/>.
    /// </summary>
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    /// <summary>
    /// Error de conflicto cuando ya existe una propiedad con el mismo código interno.
    /// </summary>
    public static Error PropertyConflict_Code(string codeInternal) => Error.Conflict(
        CodeResources.PropertyConflict,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyConflict_Code, codeInternal));

    /// <summary>
    /// Error cuando los datos generales de la propiedad son inválidos.
    /// </summary>
    public static Error PropertyDataInvalid() => Error.Problem(
        CodeResources.PropertyDataInvalid,
        PropertiesResources.PropertyDataInvalid);

    /// <summary>
    /// Error cuando la dirección de la propiedad no es válida.
    /// </summary>
    public static Error PropertyAddressInvalid() => Error.Problem(
        CodeResources.PropertyAddressInvalid,
        PropertiesResources.PropertyAddressInvalid);

    /// <summary>
    /// Error cuando el precio de la propiedad no cumple con las reglas de negocio.
    /// </summary>
    public static Error PropertyPriceInvalid(decimal price) => Error.Problem(
        CodeResources.PropertyPriceInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyPriceInvalid, price));

    /// <summary>
    /// Error cuando el año de construcción de la propiedad no es válido.
    /// </summary>
    public static Error PropertyYearInvalid(int year) => Error.Problem(
        CodeResources.PropertyYearInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyYearInvalid, year));
}