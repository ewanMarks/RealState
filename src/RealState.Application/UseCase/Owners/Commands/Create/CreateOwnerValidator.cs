using FluentValidation;
using RealState.Application.UseCase.Owners.Resource;
using System.Text.RegularExpressions;

namespace RealState.Application.UseCase.Owners.Commands.Create;

/// <summary>
/// Validador de FluentValidation para el comando <see cref="CreateOwnerCommand"/>.
/// </summary>
public sealed class CreateOwnerValidator : AbstractValidator<CreateOwnerCommand>
{
    /// <summary>
    /// Expresión regular para validar URLs http/https.
    /// </summary>
    private static readonly Regex UrlRegex =
        new(@"^https?:\/\/[^\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Inicializa las reglas de validación para <see cref="CreateOwnerCommand"/>.
    /// </summary>
    public CreateOwnerValidator()
    {
        // El nombre es obligatorio y con un máximo de 200 caracteres
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(OwnerValidationResource.NotOptionalName)
            .MaximumLength(200).WithMessage(OwnerValidationResource.MaxCharName);

        // La dirección (si se envía) no puede superar los 300 caracteres
        RuleFor(x => x.Address)
            .MaximumLength(300).When(x => x.Address is not null);

        // La foto debe ser una URL válida (http/https) o un string en Base64
        RuleFor(x => x.Photo)
            .Must(v => string.IsNullOrWhiteSpace(v) || UrlRegex.IsMatch(v!) || IsBase64(v!))
            .WithMessage(OwnerValidationResource.InvalidPhoto);

        // La fecha de nacimiento no puede ser futura
        RuleFor(x => x.Birthday)
            .Must(b => b is null || b <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage(OwnerValidationResource.InvalidBirthday);
    }

    /// <summary>
    /// Verifica si un string está en formato Base64 válido.
    /// </summary>
    private static bool IsBase64(string value)
    {
        Span<byte> buffer = stackalloc byte[(value.Length * 3) / 4];
        return Convert.TryFromBase64String(value, buffer, out _);
    }
}