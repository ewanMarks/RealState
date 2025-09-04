using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Properties;

/// <summary>
/// Implementación del repositorio <see cref="IPropertyImageRepository"/> 
/// para la entidad <see cref="PropertyImage"/>.
/// </summary>
public class PropertyImageRepository(RealStateDbContext context)
    : RealStateRepository<PropertyImage>(context), IPropertyImageRepository
{
    private readonly RealStateDbContext _context = context;

    /// <summary>
    /// Verifica si ya existe una imagen con el mismo archivo para una propiedad específica.
    /// </summary>
    public Task<bool> ExistsSameFileAsync(Guid idProperty, string file, CancellationToken cancellationToken = default) =>
        _context.PropertyImages
            .AsNoTracking()
            .AnyAsync(pi => pi.IdProperty == idProperty && pi.File == file, cancellationToken);

    /// <summary>
    /// Obtiene la cantidad de imágenes asociadas a una propiedad.
    /// </summary>
    public Task<int> CountByPropertyAsync(Guid idProperty, CancellationToken cancellationToken = default) =>
        _context.PropertyImages
            .AsNoTracking()
            .CountAsync(pi => pi.IdProperty == idProperty, cancellationToken);
}