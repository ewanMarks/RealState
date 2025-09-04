using FluentValidation;
using RealState.Application.UseCase.ChangePrice.Resources;

namespace RealState.Application.UseCase.ChangePrice.Commands.Change;

/// <summary>
/// Validador de FluentValidation para el comando <see cref="ChangePropertyPriceCommand"/>.
/// </summary>
public sealed class ChangePropertyPriceValidator : AbstractValidator<ChangePropertyPriceCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para el comando <see cref="ChangePropertyPriceCommand"/>.
    /// </summary>
    public ChangePropertyPriceValidator()
    {
        // La propiedad es obligatoria
        RuleFor(x => x.IdProperty)
            .NotEmpty().WithMessage(PropertyChangePriceValidationResource.NotOptionalProperty);

        // El nuevo precio debe ser mayor que 0
        RuleFor(x => x.NewPrice)
            .GreaterThan(0).WithMessage(PropertyChangePriceValidationResource.InvalidPrice);

        // El nombre (si se envía) no debe superar los 200 caracteres
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage(PropertyChangePriceValidationResource.MaxCharName);

        // El impuesto (si se envía) no puede ser negativo
        RuleFor(x => x.Tax)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Tax.HasValue)
            .WithMessage(PropertyChangePriceValidationResource.InvalidTax);
    }
}