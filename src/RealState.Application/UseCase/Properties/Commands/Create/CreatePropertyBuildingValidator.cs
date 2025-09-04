using FluentValidation;
using RealState.Application.UseCase.Properties.Commands.Create;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Propertiess.Commands.Create;

/// <summary>
/// Validator para la creación de propiedades (Property Building).
/// </summary>
public sealed class CreatePropertyBuildingValidator : AbstractValidator<CreatePropertyBuildingCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para <see cref="CreatePropertyBuildingCommand"/>.
    /// </summary>
    public CreatePropertyBuildingValidator()
    {
        // El Id del propietario es obligatorio
        RuleFor(x => x.IdOwner)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalOwner);

        // El nombre es requerido y tiene un máximo de 200 caracteres
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalName)
            .MaximumLength(200).WithMessage(PropertyValidationResource.MaxCharName);

        // La dirección es obligatoria y tiene un máximo de 300 caracteres
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalAddress)
            .MaximumLength(300).WithMessage(PropertyValidationResource.MaxCharAddress);

        // El código interno no puede ser nulo y tiene máximo 100 caracteres
        RuleFor(x => x.CodeInternal)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalCodeInternal)
            .MaximumLength(100).WithMessage(PropertyValidationResource.MaxCharCode);

        // El precio debe ser mayor que cero
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(PropertyValidationResource.InvalidPrice);

        // El año debe estar en un rango lógico (1800 - año actual)
        RuleFor(x => x.Year)
            .InclusiveBetween(1800, DateTime.UtcNow.Year)
            .WithMessage(PropertyValidationResource.InvalidYear);
    }
}