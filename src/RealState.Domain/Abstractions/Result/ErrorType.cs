namespace RealState.Domain.Abstractions.Result;

/// <summary>
/// Define los diferentes tipos de errores que puede manejar el sistema.
/// </summary>
public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Unauthorized = 4,
    Forbidden = 5,
    Unexpected = 6,
    Problem = 7
}