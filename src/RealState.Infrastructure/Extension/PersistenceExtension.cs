using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealState.Domain.Abstractions.Interfaces;
using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.UnitOfWorks;

namespace RealState.Infrastructure.Extension;

/// <summary>
/// Métodos de extensión para registrar la capa de persistencia en el contenedor de dependencias.
/// </summary>
public static class PersistenceExtension
{
    /// <summary>
    /// Agrega y configura la capa de persistencia para la aplicación RealState.
    /// </summary>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RealState")
            ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'RealState'.");

        services.AddDbContextPool<RealStateDbContext>((sp, options) =>
        {
            var env = sp.GetRequiredService<IHostEnvironment>();

            options.UseSqlServer(
                connectionString,
                sql =>
                {
                    sql.MigrationsAssembly(typeof(RealStateDbContext).Assembly.FullName);
                    sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                    sql.CommandTimeout(60);
                });

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            options.EnableDetailedErrors(env.IsDevelopment());
            options.EnableSensitiveDataLogging(env.IsDevelopment());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
