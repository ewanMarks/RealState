using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Infrastructure;

/// <summary>
/// Extensiones para construir respuestas personalizadas de tipo <see cref="IResult"/> 
/// en Minimal API a partir de objetos <see cref="Result"/>.
/// </summary>
public static class CustomResults
{
    /// <summary>
    /// Convierte un <see cref="Result"/> fallido en un objeto <see cref="IResult"/> con formato de <c>ProblemDetails</c>.
    /// </summary>
    public static IResult Problem(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        // Construir ProblemDetails con los valores derivados del error
        return Results.Problem(
            title: GetTitle(result.Error),
            detail: GetDetail(result.Error),
            type: GetType(result.Error.Type),
            statusCode: GetStatusCode(result.Error.Type),
            extensions: GetErrors(result));

        // Determina el título a mostrar en ProblemDetails según el tipo de error
        static string GetTitle(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => error.Code,
                ErrorType.Problem => error.Code,
                ErrorType.NotFound => error.Code,
                ErrorType.Conflict => error.Code,
                ErrorType.Unauthorized => error.Code,
                _ => "Server failure"
            };

        // Determina el detalle del error a mostrar en ProblemDetails
        static string GetDetail(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => error.Description,
                ErrorType.Problem => error.Description,
                ErrorType.NotFound => error.Description,
                ErrorType.Conflict => error.Description,
                ErrorType.Unauthorized => error.Description,
                _ => "An unexpected error occurred"
            };

        // Asigna el enlace RFC correspondiente al tipo de error
        static string GetType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                ErrorType.Unauthorized => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

        // Retorna el código de estado HTTP asociado al tipo de error
        static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

        // Retorna los errores de validación (si existen) en el campo "errors" de ProblemDetails
        static Dictionary<string, object?>? GetErrors(Result result)
        {
            if (result.Error is not ValidationError validationError)
            {
                return null;
            }

            return new Dictionary<string, object?>
            {
                { "errors", validationError.Errors }
            };
        }
    }
}
