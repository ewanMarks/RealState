using FluentValidation;
using RealState.Application.UseCase.Auth.Resources;

namespace RealState.Application.UseCase.Auth.Commands.Login;

/// <summary>
/// Validador de FluentValidation para el comando <see cref="LoginCommand"/>.
/// </summary>
public sealed class LoginValidator : AbstractValidator<LoginCommand>
{
    /// <summary>
    /// Inicializa las reglas de validación para el comando <see cref="LoginCommand"/>.
    /// </summary>
    public LoginValidator()
    {
        // El email es obligatorio y debe tener un formato válido
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthValidationResource.NotOptionalEmail)
            .EmailAddress().WithMessage(AuthValidationResource.InvalidEmail);

        // La contraseña es obligatoria y debe tener al menos 8 caracteres
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthValidationResource.NotOptionalPassword)
            .MinimumLength(8).WithMessage(AuthValidationResource.MinLengthPassword);
    }
}