using FluentValidation;
using RealState.Application.UseCase.PropertyImages.Resources;
using System.Text.RegularExpressions;

namespace RealState.Application.UseCase.PropertyImages.Commands;

/// <summary>
/// Validator para el comando <see cref="AddPropertyImageCommand"/>.
/// </summary>
public sealed class AddPropertyImageValidator : AbstractValidator<AddPropertyImageCommand>
{
    /// <summary>
    /// Expresión regular para validar URLs http/https.
    /// </summary>
    private static readonly Regex UrlRegex =
        new(@"^https?:\/\/[^\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Expresión regular para validar rutas relativas de archivo.
    /// </summary>
    private static readonly Regex RelativePathRegex =
        new(@"^(\/?[\w\-. ]+)+(\/[\w\-. ]+)*(\.[A-Za-z0-9]{2,10})?$", RegexOptions.Compiled);

    /// <summary>
    /// Inicializa las reglas de validación para <see cref="AddPropertyImageCommand"/>.
    /// </summary>
    public AddPropertyImageValidator()
    {
        RuleFor(x => x.IdProperty)
            .NotEmpty().WithMessage(PropertyImageValidationResource.NotOptionalProperty);

        RuleFor(x => x.File)
            .NotEmpty().WithMessage(PropertyImageValidationResource.NotOptionalFile)
            .MaximumLength(500).WithMessage(PropertyImageValidationResource.MaxCharFile)
            .Must(IsValidFile).WithMessage(PropertyImageValidationResource.InvalidFile);
    }

    /// <summary>
    /// Valida que el valor corresponda a una URL, Base64 o ruta relativa válida.
    /// </summary>
    private static bool IsValidFile(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        if (UrlRegex.IsMatch(value)) return true;

        if (IsBase64(value)) return true;

        if (RelativePathRegex.IsMatch(value)) return true;

        return false;
    }

    /// <summary>
    /// Verifica si un string está en formato Base64 válido.
    /// </summary>
    private static bool IsBase64(string value)
    {
        try
        {
            Span<byte> buffer = stackalloc byte[(value.Length * 3) / 4];
            return Convert.TryFromBase64String(value, buffer, out _);
        }
        catch { return false; }
    }
}