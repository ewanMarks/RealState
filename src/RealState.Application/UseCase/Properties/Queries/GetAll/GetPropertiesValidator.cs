using FluentValidation;
using RealState.Application.UseCase.Properties.Resource;

namespace RealState.Application.UseCase.Properties.Queries.GetAll;

/// <summary>
/// Validator para la query <see cref="GetAllPropertiesQuery"/>.
/// </summary>
public sealed class GetPropertiesValidator : AbstractValidator<GetAllPropertiesQuery>
{
    /// <summary>
    /// Campos permitidos para ordenamiento.
    /// </summary>
    private static readonly HashSet<string> AllowedSortBy = new(StringComparer.OrdinalIgnoreCase)
    {
        "Name", "Price", "Year", "CodeInternal", "Address", "CreatedOn", "IdOwner"
    };

    /// <summary>
    /// Direcciones de ordenamiento permitidas.
    /// </summary>
    private static readonly HashSet<string> AllowedSortDir = new(StringComparer.OrdinalIgnoreCase)
    {
        "asc", "desc"
    };

    /// <summary>
    /// Inicializa las reglas de validación para <see cref="GetAllPropertiesQuery"/>.
    /// </summary>
    public GetPropertiesValidator()
    {
        // Paginación
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage(PropertyListValidationResource.InvalidPage);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage(PropertyListValidationResource.InvalidPageSize);

        // Rangos de precios
        RuleFor(x => x.PriceMin)
            .GreaterThanOrEqualTo(0)
            .When(x => x.PriceMin.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        RuleFor(x => x.PriceMax)
            .GreaterThanOrEqualTo(0)
            .When(x => x.PriceMax.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        // Validación: PriceMin <= PriceMax
        RuleFor(x => x)
            .Must(r => !r.PriceMin.HasValue || !r.PriceMax.HasValue || r.PriceMin <= r.PriceMax)
            .WithMessage(PropertyListValidationResource.InvalidPriceRange);

        // Rangos de año
        RuleFor(x => x.YearMin)
            .GreaterThanOrEqualTo(1800)
            .When(x => x.YearMin.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        RuleFor(x => x.YearMax)
            .GreaterThanOrEqualTo(1800)
            .When(x => x.YearMax.HasValue)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        // Validación: YearMin <= YearMax
        RuleFor(x => x)
            .Must(r => !r.YearMin.HasValue || !r.YearMax.HasValue || r.YearMin <= r.YearMax)
            .WithMessage(PropertyListValidationResource.InvalidYearRange);

        // Rango de fechas de creación (CreatedFrom <= CreatedTo)
        RuleFor(x => x)
            .Must(r => !r.CreatedFrom.HasValue || !r.CreatedTo.HasValue || r.CreatedFrom <= r.CreatedTo)
            .WithMessage(PropertyListValidationResource.InvalidCreatedRange);

        // Ordenamiento por campo permitido
        RuleFor(x => x.SortBy)
            .Must(sb => string.IsNullOrWhiteSpace(sb) || AllowedSortBy.Contains(sb))
            .WithMessage(PropertyListValidationResource.InvalidSortBy);

        // Dirección de ordenamiento permitida (asc/desc)
        RuleFor(x => x.SortDir)
            .Must(sd => string.IsNullOrWhiteSpace(sd) || AllowedSortDir.Contains(sd))
            .WithMessage(PropertyListValidationResource.InvalidSortDir);
    }
}