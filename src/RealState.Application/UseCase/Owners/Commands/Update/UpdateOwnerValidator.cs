using FluentValidation;
using RealState.Application.UseCase.Owners.Resource;
using System.Text.RegularExpressions;

namespace RealState.Application.UseCase.Owners.Commands.Update;

public sealed class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
{
    private static readonly Regex UrlRegex =
        new(@"^https?:\/\/[^\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public UpdateOwnerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(OwnerValidationResource.NotOptionalName)
            .MaximumLength(150);

        RuleFor(x => x.Address)
            .MaximumLength(250).When(x => x.Address is not null);

        RuleFor(x => x.Photo)
            .Must(v => string.IsNullOrWhiteSpace(v) || UrlRegex.IsMatch(v!) || IsBase64(v!))
            .WithMessage(OwnerValidationResource.InvalidPhoto);

        RuleFor(x => x.Birthday)
            .Must(b => b is null || b <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage(OwnerValidationResource.InvalidBirthday);
    }

    private static bool IsBase64(string value)
    {
        Span<byte> buffer = stackalloc byte[(value.Length * 3) / 4];
        return Convert.TryFromBase64String(value, buffer, out _);
    }
}
