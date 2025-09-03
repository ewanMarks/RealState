using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Properties.Errors;

public static class PropertyErrors
{
    public static Error OwnerNotFound(Guid ownerId) => Error.NotFound(
        CodeResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.OwnerNotFound_Id, ownerId));

    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodeResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyNotFound_Id, propertyId));

    public static Error PropertyConflict_Code(string codeInternal) => Error.Conflict(
        CodeResources.PropertyConflict,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyConflict_Code, codeInternal));

    public static Error PropertyDataInvalid() => Error.Problem(
        CodeResources.PropertyDataInvalid,
        PropertiesResources.PropertyDataInvalid);

    public static Error PropertyAddressInvalid() => Error.Problem(
        CodeResources.PropertyAddressInvalid,
        PropertiesResources.PropertyAddressInvalid);

    public static Error PropertyPriceInvalid(decimal price) => Error.Problem(
        CodeResources.PropertyPriceInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyPriceInvalid, price));

    public static Error PropertyYearInvalid(int year) => Error.Problem(
        CodeResources.PropertyYearInvalid,
        string.Format(CultureInfo.InvariantCulture, PropertiesResources.PropertyYearInvalid, year));
}