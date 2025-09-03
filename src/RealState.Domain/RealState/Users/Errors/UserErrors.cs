using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Users.Resources;
using System.Globalization;

namespace RealState.Domain.RealState.Users.Errors;

public static class UserErrors
{
    public static Error UserNotFound(string email) => Error.NotFound(
        CodesResources.UserNotFound,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserNotFound_Email, email));

    public static Error UserInactive(string email) => Error.Problem(
        CodesResources.UserInactive,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserInactive_Email, email));

    public static Error InvalidCredentials() => Error.Unauthorized(
        CodesResources.InvalidCredentials,
        UsersResources.InvalidCredentials);

    public static Error UserConflict(string email) => Error.Conflict(
        CodesResources.UserConflict,
        string.Format(CultureInfo.InvariantCulture, UsersResources.UserConflict_Email, email));

    public static Error UserDataInvalid() => Error.Problem(
        CodesResources.UserDataInvalid,
        UsersResources.UserDataInvalid);
}
