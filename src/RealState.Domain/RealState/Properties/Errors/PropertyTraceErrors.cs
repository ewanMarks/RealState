using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

public static class PropertyTraceErrors
{
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    public static Error PropertyPriceInvalid(decimal price) => Error.Problem(
        CodeResources.PropertyPriceInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyPriceInvalid, price));

    public static Error PropertyTraceDataInvalid() => Error.Problem(
        CodeResources.PropertyTraceDataInvalid,
        PropertiesResources.PropertyTraceDataInvalid);
}