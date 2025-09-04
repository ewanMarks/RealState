using FluentValidation;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Properties.Commands.Update;

/// <summary>
/// Validator para el comando <see cref="UpdatePropertyCommand"/>.
/// </summary>
public sealed class UpdatePropertyValidator : AbstractValidator<UpdatePropertyCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para <see cref="UpdatePropertyCommand"/>.
    /// </summary>
    public UpdatePropertyValidator()
    {
        // El Id de la propiedad es obligatorio
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalId);

        // El nombre es obligatorio y no puede superar los 200 caracteres
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalName)
            .MaximumLength(200).WithMessage(PropertyValidationResource.MaxCharName);

        // La dirección es obligatoria y no puede superar los 300 caracteres
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalAddress)
            .MaximumLength(300).WithMessage(PropertyValidationResource.MaxCharAddress);

        // El código interno es obligatorio y con máximo de 100 caracteres
        RuleFor(x => x.CodeInternal)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalCodeInternal)
            .MaximumLength(100).WithMessage(PropertyValidationResource.MaxCharCode);

        // El año debe estar dentro de un rango válido (1800 - año actual)
        RuleFor(x => x.Year)
            .InclusiveBetween(1800, DateTime.UtcNow.Year)
            .WithMessage(PropertyValidationResource.InvalidYear);
    }
}