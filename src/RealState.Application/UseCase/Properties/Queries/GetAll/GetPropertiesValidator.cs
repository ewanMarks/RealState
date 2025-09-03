using FluentValidation;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Properties.Queries.GetAll;

public sealed class GetPropertiesValidator : AbstractValidator<GetAllPropertiesQuery>
{
    private static readonly HashSet<string> AllowedSortBy = new(StringComparer.OrdinalIgnoreCase)
    {
        "Name", "Price", "Year", "CodeInternal", "Address", "CreatedOn", "IdOwner"
    };

    private static readonly HashSet<string> AllowedSortDir = new(StringComparer.OrdinalIgnoreCase)
    {
        "asc", "desc"
    };

    public GetPropertiesValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage(PropertyListValidationResource.InvalidPage);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage(PropertyListValidationResource.InvalidPageSize);

        RuleFor(x => x.PriceMin)
            .GreaterThanOrEqualTo(0)
            .When(x => x.PriceMin.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        RuleFor(x => x.PriceMax)
            .GreaterThanOrEqualTo(0)
            .When(x => x.PriceMax.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        RuleFor(x => x)
            .Must(r => !r.PriceMin.HasValue || !r.PriceMax.HasValue || r.PriceMin <= r.PriceMax)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        RuleFor(x => x.YearMin)
            .GreaterThanOrEqualTo(1800)
            .When(x => x.YearMin.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        RuleFor(x => x.YearMax)
            .GreaterThanOrEqualTo(1800)
            .When(x => x.YearMax.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        RuleFor(x => x)
            .Must(r => !r.YearMin.HasValue || !r.YearMax.HasValue || r.YearMin <= r.YearMax)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        RuleFor(x => x)
            .Must(r => !r.CreatedFrom.HasValue || !r.CreatedTo.HasValue || r.CreatedFrom <= r.CreatedTo)
            .WithMessage(PropertyListValidationResource.InvalidCreatedRange);

        RuleFor(x => x.SortBy)
            .Must(sb => string.IsNullOrWhiteSpace(sb) || AllowedSortBy.Contains(sb))
            .WithMessage(PropertyListValidationResource.InvalidSortBy);

        RuleFor(x => x.SortDir)
            .Must(sd => string.IsNullOrWhiteSpace(sd) || AllowedSortDir.Contains(sd))
            .WithMessage(PropertyListValidationResource.InvalidSortDir);
    }
}