using FluentValidation;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Properties.Commands.Update;

public sealed class UpdatePropertyValidator : AbstractValidator<UpdatePropertyCommand>
{
    public UpdatePropertyValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalId);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalName)
            .MaximumLength(200).WithMessage(PropertyValidationResource.MaxCharName);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalAddress)
            .MaximumLength(300).WithMessage(PropertyValidationResource.MaxCharAddress);

        RuleFor(x => x.CodeInternal)
            .NotEmpty().WithMessage(PropertyValidationResource.NotOptionalCodeInternal)
            .MaximumLength(100).WithMessage(PropertyValidationResource.MaxCharCode);

        RuleFor(x => x.Year)
            .InclusiveBetween(1800, DateTime.UtcNow.Year)
            .WithMessage(PropertyValidationResource.InvalidYear);
    }
}