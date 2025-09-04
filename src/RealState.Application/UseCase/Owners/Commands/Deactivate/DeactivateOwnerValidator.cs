using FluentValidation;
using RealState.Application.UseCase.Owners.Commands.Desactivate;
using RealState.Application.UseCase.Owners.Resource;

namespace RealState.Application.UseCase.Owners.Commands.Deactivate;

/// <summary>
/// Validador de FluentValidation para el comando <see cref="DeactivateOwnerCommand"/>.
/// </summary>
public sealed class DeactivateOwnerValidator : AbstractValidator<DeactivateOwnerCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para <see cref="DeactivateOwnerCommand"/>.
    /// </summary>
    public DeactivateOwnerValidator()
    {
        // El Id del propietario es obligatorio
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(OwnerValidationResource.NotOptionalId);
    }
}
