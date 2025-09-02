using FluentValidation;

namespace RealState.Application.UseCase.Owners.Commands.Delete;

public sealed class DeleteOwnerValidator : AbstractValidator<DeleteOwnerCommand>
{
    public DeleteOwnerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}