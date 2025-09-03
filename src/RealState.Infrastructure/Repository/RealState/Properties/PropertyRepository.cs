using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Domain.RealState.Properties.ValueObjects;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Properties;

public class PropertyRepository(RealStateDbContext context)
    : RealStateRepository<Property>(context), IPropertyRepository
{
    private readonly RealStateDbContext _context = context;

    public Task<bool> CodeInternalExistsAsync(string codeInternal, CancellationToken cancellationToken = default) =>
        _context.Properties
            .AsNoTracking()
            .AnyAsync(p => p.CodeInternal == codeInternal, cancellationToken);

    public Task<bool> CodeInternalExistsForOtherAsync(Guid idProperty, string codeInternal, CancellationToken cancellationToken = default) =>
        _context.Properties
            .AsNoTracking()
            .AnyAsync(p => p.Id != idProperty && p.CodeInternal == codeInternal, cancellationToken);

    public async Task<IReadOnlyList<Property>> GetListAsync(PropertyFilters filters, CancellationToken cancellationToken = default)
    {
        var query = ApplyFilters(_context.Properties.AsNoTracking(), filters);

        query = ApplySorting(query, filters);

        int page = filters.Page <= 0 ? 1 : filters.Page;
        int pageSize = filters.PageSize <= 0 ? 10 : filters.PageSize;

        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public Task<int> CountAsync(PropertyFilters filters, CancellationToken cancellationToken = default)
    {
        var query = ApplyFilters(_context.Properties.AsNoTracking(), filters);
        return query.CountAsync(cancellationToken);
    }

    #region Métodos Privados
    private static IQueryable<Property> ApplyFilters(IQueryable<Property> source, PropertyFilters f)
    {
        if (f.IdOwner.HasValue)
        {
            source = source.Where(p => p.IdOwner == f.IdOwner.Value);
        }

        if (!string.IsNullOrWhiteSpace(f.Name))
        {
            source = source.Where(p => EF.Functions.Like(p.Name, $"%{f.Name}%"));
        }

        if (!string.IsNullOrWhiteSpace(f.Address))
        {
            source = source.Where(p => EF.Functions.Like(p.Address, $"%{f.Address}%"));
        }

        if (!string.IsNullOrWhiteSpace(f.CodeInternal))
        {
            source = source.Where(p => EF.Functions.Like(p.CodeInternal, $"%{f.CodeInternal}%"));
        }

        if (f.PriceMin.HasValue)
        {
            source = source.Where(p => p.Price >= f.PriceMin.Value);
        }

        if (f.PriceMax.HasValue)
        {
            source = source.Where(p => p.Price <= f.PriceMax.Value);
        }

        if (f.YearMin.HasValue)
        {
            source = source.Where(p => p.Year >= f.YearMin.Value);
        }

        if (f.YearMax.HasValue)
        {
            source = source.Where(p => p.Year <= f.YearMax.Value);
        }

        if (f.CreatedFrom.HasValue)
        {
            source = source.Where(p => p.CreatedOn >= f.CreatedFrom.Value);
        }

        if (f.CreatedTo.HasValue)
        {
            source = source.Where(p => p.CreatedOn <= f.CreatedTo.Value);
        }

        return source;
    }

    private static IQueryable<Property> ApplySorting(IQueryable<Property> source, PropertyFilters f)
    {
        var sortBy = (f.SortBy ?? "CreatedOn").Trim();
        var sortDir = (f.SortDir ?? "desc").Trim().ToLowerInvariant();

        return (sortBy.ToLowerInvariant(), sortDir) switch
        {
            ("name", "asc") => source.OrderBy(p => p.Name),
            ("name", "desc") => source.OrderByDescending(p => p.Name),

            ("price", "asc") => source.OrderBy(p => p.Price),
            ("price", "desc") => source.OrderByDescending(p => p.Price),

            ("year", "asc") => source.OrderBy(p => p.Year),
            ("year", "desc") => source.OrderByDescending(p => p.Year),

            ("codeinternal", "asc") => source.OrderBy(p => p.CodeInternal),
            ("codeinternal", "desc") => source.OrderByDescending(p => p.CodeInternal),

            ("address", "asc") => source.OrderBy(p => p.Address),
            ("address", "desc") => source.OrderByDescending(p => p.Address),

            ("createdon", "asc") => source.OrderBy(p => p.CreatedOn),
            ("createdon", "desc") => source.OrderByDescending(p => p.CreatedOn),

            ("idowner", "asc") => source.OrderBy(p => p.IdOwner),
            ("idowner", "desc") => source.OrderByDescending(p => p.IdOwner),

            _ => source.OrderByDescending(p => p.CreatedOn)
        };
    }
    #endregion
}