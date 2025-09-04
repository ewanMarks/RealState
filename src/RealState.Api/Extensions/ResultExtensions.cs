using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Extensions;

/// <summary>
/// Métodos de extensión para trabajar con el patrón <see cref="Result"/>.
/// Permiten ejecutar funciones diferentes según si el resultado fue exitoso o fallido.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Ejecuta una de dos funciones dependiendo de si el <see cref="Result"/> fue exitoso o no.
    /// </summary>
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    /// <summary>
    /// Ejecuta una de dos funciones dependiendo de si el <see cref="Result{TIn}"/> fue exitoso o no.
    /// </summary>
    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}
