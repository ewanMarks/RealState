using FluentValidation;
using RealState.Application.UseCase.Owners.Commands.Desactivate;
using RealState.Application.UseCase.Owners.Resource;

namespace RealState.Application.UseCase.Owners.Commands.Deactivate;

public sealed class DeactivateOwnerValidator : AbstractValidator<DeactivateOwnerCommand>
{
    public DeactivateOwnerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(OwnerValidationResource.NotOptionalId);
    }
}
