namespace RealState.Domain.RealState.Properties.ValueObjects;

public sealed record PropertyFilters(
    Guid? IdOwner,
    string? Name,
    string? Address,
    string? CodeInternal,
    decimal? PriceMin,
    decimal? PriceMax,
    int? YearMin,
    int? YearMax,
    DateTime? CreatedFrom,
    DateTime? CreatedTo,
    int Page,
    int PageSize,
    string? SortBy,
    string? SortDir
);