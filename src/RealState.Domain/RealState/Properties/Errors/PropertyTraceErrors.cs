using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

/// <summary>
/// Contiene los errores de negocio específicos para la entidad <see cref="PropertyTrace"/>.
/// </summary>
public static class PropertyTraceErrors
{
    /// <summary>
    /// Error cuando no se encuentra la propiedad asociada al <paramref name="propertyId"/>.
    /// </summary>
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    /// <summary>
    /// Error cuando el precio asociado a una traza de propiedad no es válido.
    /// </summary>
    public static Error PropertyPriceInvalid(decimal price) => Error.Problem(
        CodeResources.PropertyPriceInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyPriceInvalid, price));

    /// <summary>
    /// Error cuando los datos generales de la traza de propiedad son inválidos.
    /// </summary>
    public static Error PropertyTraceDataInvalid() => Error.Problem(
        CodeResources.PropertyTraceDataInvalid,
        PropertiesResources.PropertyTraceDataInvalid);
}