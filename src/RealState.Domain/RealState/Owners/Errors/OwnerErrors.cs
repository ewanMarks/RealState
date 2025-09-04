using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Owners.Errors;

/// <summary>
/// Contiene los errores de negocio específicos para la entidad <see cref="Owner"/>.
/// </summary>
public static class OwnerErrors
{
    /// <summary>
    /// Error cuando no se encuentra un propietario por <paramref name="ownerId"/>.
    /// </summary>
    public static Error OwnerNotFound(Guid ownerId) => Error.NotFound(
        CodesResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerNotFound_Id, ownerId));

    /// <summary>
    /// Error cuando no se encuentra un propietario por <paramref name="ownerName"/>.
    /// </summary>
    public static Error OwnerNotFound(string ownerName) => Error.NotFound(
        CodesResources.OwnerNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerNotFound_Name, ownerName));

    /// <summary>
    /// Error de conflicto cuando ya existe un propietario con el mismo nombre.
    /// </summary>
    public static Error OwnerConflict(string ownerName) => Error.Conflict(
        CodesResources.OwnerConflict,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerConflict_Name, ownerName));

    /// <summary>
    /// Error cuando los datos del propietario son inválidos.
    /// </summary>
    public static Error OwnerDataInvalid() => Error.Problem(
        CodesResources.OwnerDataInvalid,
        OwnersResources.OwnerDataInvalid);

    /// <summary>
    /// Error cuando no se encuentra una propiedad asociada a un <paramref name="propertyId"/>.
    /// </summary>
    public static Error PropertyNotFound(Guid propertyId) => Error.NotFound(
        CodesResources.PropertyNotFound,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.PropertyNotFound_Id, propertyId));

    /// <summary>
    /// Error de conflicto cuando un propietario tiene propiedades asociadas y se intenta eliminar.
    /// </summary>
    public static Error OwnerHasLinkedProperties(Guid ownerId) => Error.Conflict(
        CodesResources.OwnerHasLinkedProperties,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerHasLinkedProperties, ownerId));

    /// <summary>
    /// Error cuando la fecha de nacimiento del propietario es inválida.
    /// </summary>
    public static Error OwnerBirthdayInvalid(DateOnly birthday) => Error.Problem(
        CodesResources.OwnerBirthdayInvalid,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerBirthdayInvalid, birthday));

    /// <summary>
    /// Error cuando la foto del propietario es inválida.
    /// </summary>
    public static Error OwnerPhotoInvalid() => Error.Problem(
        CodesResources.OwnerPhotoInvalid,
        OwnersResources.OwnerPhotoInvalid);

    /// <summary>
    /// Error de conflicto cuando el propietario ya está inactivo y se intenta desactivar de nuevo.
    /// </summary>
    public static Error OwnerAlreadyInactive(Guid ownerId) => Error.Conflict(
        CodesResources.OwnerAlreadyInactive,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerAlreadyInactive_Id, ownerId));

    /// <summary>
    /// Error de conflicto cuando el propietario ya está activo y se intenta activar de nuevo.
    /// </summary>
    public static Error OwnerAlreadyActive(Guid ownerId) => Error.Conflict(
        CodesResources.OwnerAlreadyActive,
        string.Format(CultureInfo.InvariantCulture, OwnersResources.OwnerAlreadyActive_Id, ownerId));
}
