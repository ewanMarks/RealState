using FluentValidation;
using RealState.Application.UseCase.ChangePrice.Resources;

namespace RealState.Application.UseCase.ChangePrice.Commands.Change;

public sealed class ChangePropertyPriceValidator : AbstractValidator<ChangePropertyPriceCommand>
{
    public ChangePropertyPriceValidator()
    {
        RuleFor(x => x.IdProperty)
            .NotEmpty().WithMessage(PropertyChangePriceValidationResource.NotOptionalProperty);

        RuleFor(x => x.NewPrice)
            .GreaterThan(0).WithMessage(PropertyChangePriceValidationResource.InvalidPrice);

        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage(PropertyChangePriceValidationResource.MaxCharName);

        RuleFor(x => x.Tax)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Tax.HasValue)
            .WithMessage(PropertyChangePriceValidationResource.InvalidTax);
    }
}