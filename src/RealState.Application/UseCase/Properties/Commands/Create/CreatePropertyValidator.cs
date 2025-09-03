using FluentValidation;
using RealState.Application.UseCase.Properties.Commands.Create;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Propertiess.Commands.Create;

public sealed class CreatePropertyBuildingValidator : AbstractValidator<CreatePropertyBuildingCommand>
{
    public CreatePropertyBuildingValidator()
    {
        RuleFor(x => x.IdOwner)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalOwner);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalName)
            .MaximumLength(200).WithMessage(PropertyValidationResource.MaxCharName);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalAddress)
            .MaximumLength(300).WithMessage(PropertyValidationResource.MaxCharAddress);

        RuleFor(x => x.CodeInternal)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalCodeInternal)
            .MaximumLength(100).WithMessage(PropertyValidationResource.MaxCharCode);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(PropertyValidationResource.InvalidPrice);

        RuleFor(x => x.Year)
            .InclusiveBetween(1800, DateTime.UtcNow.Year)
            .WithMessage(PropertyValidationResource.InvalidYear);
    }
}