using FluentValidation;

namespace RealState.Application.UseCase.Owners.Commands.Delete;

/// <summary>
/// Validator para el comando <see cref="DeleteOwnerCommand"/>.
/// </summary>
public sealed class DeleteOwnerValidator : AbstractValidator<DeleteOwnerCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para <see cref="DeleteOwnerCommand"/>.
    /// </summary>
    public DeleteOwnerValidator()
    {
        // El Id del propietario es obligatorio
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}