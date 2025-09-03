using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Properties;

public class PropertyImageRepository(RealStateDbContext context)
    : RealStateRepository<PropertyImage>(context), IPropertyImageRepository
{
    private readonly RealStateDbContext _context = context;

    public Task<bool> ExistsSameFileAsync(Guid idProperty, string file, CancellationToken cancellationToken = default) =>
        _context.PropertyImages
            .AsNoTracking()
            .AnyAsync(pi => pi.IdProperty == idProperty && pi.File == file, cancellationToken);

    public Task<int> CountByPropertyAsync(Guid idProperty, CancellationToken cancellationToken = default) =>
        _context.PropertyImages
            .AsNoTracking()
            .CountAsync(pi => pi.IdProperty == idProperty, cancellationToken);
}