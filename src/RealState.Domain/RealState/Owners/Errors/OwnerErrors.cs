using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Owners.Errors;

public static class OwnerErrors
{
    public static Error OwnerNotFound(Guid ownerId) => Error.NotFound(
        CodesResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerNotFound_Id, ownerId));

    public static Error OwnerNotFound(string ownerName) => Error.NotFound(
        CodesResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerNotFound_Name, ownerName));

    public static Error OwnerConflict(string ownerName) => Error.Conflict(
        CodesResources.OwnerConflict,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerConflict_Name, ownerName));

    public static Error OwnerDataInvalid() => Error.Problem(
        CodesResources.OwnerDataInvalid,
        OwnersResources.OwnerDataInvalid);

    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodesResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.PropertyNotFound_Id, propertyId));

    public static Error OwnerHasLinkedProperties(Guid ownerId) => Error.Conflict(
        CodesResources.OwnerHasLinkedProperties,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerHasLinkedProperties, ownerId));

    public static Error OwnerBirthdayInvalid(DateOnly birthday) => Error.Problem(
        CodesResources.OwnerBirthdayInvalid,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerBirthdayInvalid, birthday));

    public static Error OwnerPhotoInvalid() => Error.Problem(
        CodesResources.OwnerPhotoInvalid,
        OwnersResources.OwnerPhotoInvalid);

}
