using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Users.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Users.Errors;

/// <summary>
/// Contiene los errores de negocio específicos para la entidad <see cref="User"/>.
/// </summary>
public static class UserErrors
{
    /// <summary>
    /// Error cuando no se encuentra un usuario por correo electrónico.
    /// </summary>
    public static Error UserNotFound(string email) => Error.NotFound(
        CodesResources.UserNotFound,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserNotFound_Email, email));

    /// <summary>
    /// Error cuando el usuario existe pero está inactivo.
    /// </summary>
    public static Error UserInactive(string email) => Error.Problem(
        CodesResources.UserInactive,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserInactive_Email, email));

    /// <summary>
    /// Error cuando las credenciales de acceso son inválidas.
    /// </summary>
    public static Error InvalidCredentials() => Error.Unauthorized(
        CodesResources.InvalidCredentials,
        UsersResources.InvalidCredentials);

    /// <summary>
    /// Error de conflicto cuando ya existe un usuario registrado con el mismo correo electrónico.
    /// </summary>
    public static Error UserConflict(string email) => Error.Conflict(
        CodesResources.UserConflict,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserConflict_Email, email));

    /// <summary>
    /// Error cuando los datos generales del usuario son inválidos.
    /// </summary>
    public static Error UserDataInvalid() => Error.Problem(
        CodesResources.UserDataInvalid,
        UsersResources.UserDataInvalid);
}
