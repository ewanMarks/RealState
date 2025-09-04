using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Seeders;

namespace RealState.Infrastructure.Extension;

/// <summary>
/// Métodos de extensión para ejecutar los seeders de la base de datos.
/// </summary>
public static class SeederExtensions
{
    /// <summary>
    /// Ejecuta los seeders configurados para inicializar la base de datos <see cref="RealStateDbContext"/>.
    /// </summary>
    public static async Task RunSeedersAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("SeederRunner");
        var realStateContext = scope.ServiceProvider.GetRequiredService<RealStateDbContext>();

        var strategy = realStateContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await realStateContext.Database.BeginTransactionAsync();
            try
            {
                var seederManager = new SeederManager();

                logger.LogInformation("Iniciando seeders para RealStateDbContext...");
                await seederManager.SeedRealStateDatabase(realStateContext);

                await realStateContext.SaveChangesAsync();

                await transaction.CommitAsync();
                logger.LogInformation("Seeders ejecutados correctamente.");
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
    }

}