using FluentValidation;
using RealState.Application.UseCase.Owners.Resource;

namespace RealState.Application.UseCase.Owners.Queries.GetAll;

/// <summary>
/// Validador de FluentValidation para la query <see cref="GetAllOwnersQuery"/>.
/// </summary>
public sealed class GetOwnersValidator : AbstractValidator<GetAllOwnersQuery>
{
    /// <summary>
    /// Conjunto de campos permitidos para ordenamiento.
    /// </summary>
    private static readonly HashSet<string> AllowedSortBy = new(StringComparer.OrdinalIgnoreCase)
    {
        "Name", "Address", "Birthday", "CreatedOn"
    };

    /// <summary>
    /// Direcciones de ordenamiento permitidas.
    /// </summary>
    private static readonly HashSet<string> AllowedSortDir = new(StringComparer.OrdinalIgnoreCase)
    {
        "asc", "desc"
    };

    /// <summary>
    /// Inicializa las reglas de validación para <see cref="GetAllOwnersQuery"/>.
    /// </summary>
    public GetOwnersValidator()
    {
        // Paginación
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage(OwnerListValidationResource.InvalidPage);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage(OwnerListValidationResource.InvalidPageSize);

        // Rango de cumpleaños (min <= max)
        RuleFor(x => x)
            .Must(r => !r.BirthdayMin.HasValue || !r.BirthdayMax.HasValue || r.BirthdayMin <= r.BirthdayMax)
            .WithMessage(OwnerListValidationResource.InvalidBirthdayRange);

        // Rango de creación (from <= to)
        RuleFor(x => x)
            .Must(r => !r.CreatedFrom.HasValue || !r.CreatedTo.HasValue || r.CreatedFrom <= r.CreatedTo)
            .WithMessage(OwnerListValidationResource.InvalidCreatedRange);

        // Normalización ligera (trim) antes de validar SortBy/SortDir
        RuleFor(x => x.SortBy)
            .Must(sb => string.IsNullOrWhiteSpace(sb) || AllowedSortBy.Contains(sb))
            .WithMessage(OwnerListValidationResource.InvalidSortBy);

        RuleFor(x => x.SortDir)
            .Must(sd => string.IsNullOrWhiteSpace(sd) || AllowedSortDir.Contains(sd))
            .WithMessage(OwnerListValidationResource.InvalidSortDir);
    }
}