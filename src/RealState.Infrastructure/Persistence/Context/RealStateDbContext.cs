using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Context;

public class RealStateDbContext(DbContextOptions<RealStateDbContext> options) : DbContext(options)
{
    #region DbSets
    /// <summary>
    /// DbSet Owner Schema
    /// </summary>
    public DbSet<Owner> Owners => Set<Owner>();

    /// <summary>
    /// DbSet Property Schema
    /// </summary>
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
    public DbSet<PropertyTrace> PropertyTraces => Set<PropertyTrace>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealStateDbContext).Assembly);
    }
    #endregion
}
