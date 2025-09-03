namespace RealState.Domain.RealState.Owners.ValueObjects;

public sealed record OwnerFilters(
    string? Name,
    string? Address,
    DateOnly? BirthdayMin,
    DateOnly? BirthdayMax,
    DateTime? CreatedFrom,
    DateTime? CreatedTo,
    int Page,
    int PageSize,
    string? SortBy,
    string? SortDir
);
