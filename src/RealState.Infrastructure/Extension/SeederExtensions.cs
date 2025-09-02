using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Seeders;

namespace RealState.Infrastructure.Extension;

public static class SeederExtensions
{
    public static async Task RunSeedersAsync(this IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        ILogger logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>()
                                          .CreateLogger("SeederRunner");

        RealStateDbContext realStateContext = scope.ServiceProvider.GetRequiredService<RealStateDbContext>();

        await using IDbContextTransaction transaction = await realStateContext.Database.BeginTransactionAsync();
        try
        {
            var seederManager = new SeederManager();

            logger.LogInformation("Iniciando seeders para RealStateDbContext...");
            await seederManager.SeedRealStateDatabase(realStateContext);

            await transaction.CommitAsync();
            logger.LogInformation("Seeders ejecutados correctamente.");
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}