using FluentValidation;
using RealState.Application.UseCase.Auth.Resources;

namespace RealState.Application.UseCase.Auth.Commands.Login;

public sealed class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthValidationResource.NotOptionalEmail)
            .EmailAddress().WithMessage(AuthValidationResource.InvalidEmail);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthValidationResource.NotOptionalPassword)
            .MinimumLength(8).WithMessage(AuthValidationResource.MinLengthPassword);
    }
}