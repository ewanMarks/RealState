using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Domain.RealState.Owners.ValueObjects;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Owners;

public class OwnerRepository(RealStateDbContext context)
    : RealStateRepository<Owner>(context), IOwnerRepository
{
    private readonly RealStateDbContext _context = context;

    public Task<bool> HasLinkedPropertiesAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        _context.Properties.AsNoTracking()
            .AnyAsync(p => p.IdOwner == ownerId, cancellationToken);

    public async Task<IReadOnlyList<Owner>> GetListAsync(OwnerFilters filters, CancellationToken cancellationToken = default)
    {
        var query = ApplyFilters(_context.Owners.AsNoTracking(), filters);
        query = ApplySorting(query, filters);

        int page = filters.Page <= 0 ? 1 : filters.Page;
        int pageSize = filters.PageSize <= 0 ? 10 : filters.PageSize;

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public Task<int> CountAsync(OwnerFilters filters, CancellationToken cancellationToken = default)
    {
        var query = ApplyFilters(_context.Owners.AsNoTracking(), filters);
        return query.CountAsync(cancellationToken);
    }

    #region Métodos Privados
    private static IQueryable<Owner> ApplyFilters(IQueryable<Owner> source, OwnerFilters f)
    {
        if (!string.IsNullOrWhiteSpace(f.Name))
            source = source.Where(o => EF.Functions.Like(o.Name, $"%{f.Name}%"));

        if (!string.IsNullOrWhiteSpace(f.Address))
            source = source.Where(o => EF.Functions.Like(o.Address!, $"%{f.Address}%"));

        if (f.BirthdayMin.HasValue)
            source = source.Where(o => o.Birthday.HasValue && o.Birthday.Value >= f.BirthdayMin.Value);

        if (f.BirthdayMax.HasValue)
            source = source.Where(o => o.Birthday.HasValue && o.Birthday.Value <= f.BirthdayMax.Value);

        if (f.CreatedFrom.HasValue)
            source = source.Where(o => o.CreatedOn >= f.CreatedFrom.Value);

        if (f.CreatedTo.HasValue)
            source = source.Where(o => o.CreatedOn <= f.CreatedTo.Value);

        return source;
    }

    private static IQueryable<Owner> ApplySorting(IQueryable<Owner> source, OwnerFilters f)
    {
        var sortBy = (f.SortBy ?? "CreatedOn").Trim();
        var sortDir = (f.SortDir ?? "desc").Trim().ToLowerInvariant();

        return (sortBy.ToLowerInvariant(), sortDir) switch
        {
            ("name", "asc") => source.OrderBy(o => o.Name),
            ("name", "desc") => source.OrderByDescending(o => o.Name),

            ("address", "asc") => source.OrderBy(o => o.Address),
            ("address", "desc") => source.OrderByDescending(o => o.Address),

            ("birthday", "asc") => source.OrderBy(o => o.Birthday),
            ("birthday", "desc") => source.OrderByDescending(o => o.Birthday),

            ("createdon", "asc") => source.OrderBy(o => o.CreatedOn),
            ("createdon", "desc") => source.OrderByDescending(o => o.CreatedOn),

            _ => source.OrderByDescending(o => o.CreatedOn)
        };
    }
    #endregion
}
