using FluentValidation;
using RealState.Application.UseCase.Owners.Resource;

namespace RealState.Application.UseCase.Owners.Queries.GetAll;

public sealed class GetOwnersValidator : AbstractValidator<GetAllOwnersQuery>
{
    private static readonly HashSet<string> AllowedSortBy = new(StringComparer.OrdinalIgnoreCase)
    {
        "Name", "Address", "Birthday", "CreatedOn"
    };

    private static readonly HashSet<string> AllowedSortDir = new(StringComparer.OrdinalIgnoreCase)
    {
        "asc", "desc"
    };

    public GetOwnersValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage(OwnerListValidationResource.InvalidPage);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage(OwnerListValidationResource.InvalidPageSize);

        RuleFor(x => x)
            .Must(r => !r.BirthdayMin.HasValue || !r.BirthdayMax.HasValue || r.BirthdayMin <= r.BirthdayMax)
            .WithMessage(OwnerListValidationResource.InvalidBirthdayRange);

        RuleFor(x => x)
            .Must(r => !r.CreatedFrom.HasValue || !r.CreatedTo.HasValue || r.CreatedFrom <= r.CreatedTo)
            .WithMessage(OwnerListValidationResource.InvalidCreatedRange);

        RuleFor(x => x.SortBy)
            .Must(sb => string.IsNullOrWhiteSpace(sb) || AllowedSortBy.Contains(sb))
            .WithMessage(OwnerListValidationResource.InvalidSortBy);

        RuleFor(x => x.SortDir)
            .Must(sd => string.IsNullOrWhiteSpace(sd) || AllowedSortDir.Contains(sd))
            .WithMessage(OwnerListValidationResource.InvalidSortDir);
    }
}