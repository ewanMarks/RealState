using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Seeders.RealState;

namespace RealState.Infrastructure.Seeders;

/// <summary>
/// Administrador encargado de ejecutar los seeders de la base de datos RealState.
/// </summary>
public class SeederManager
{
    private readonly List<ISeeder<RealStateDbContext>> seedersRealState;

    /// <summary>
    /// Inicializa el administrador con la lista de seeders a ejecutar.
    /// </summary>
    public SeederManager()
    {
        seedersRealState =
        [
            new OwnerSeeder(),
            new PropertySeeder(),
            new PropertyImageSeeder(),
            new PropertyTraceSeeder(),
            new UserSeeder()
        ];
    }

    /// <summary>
    /// Ejecuta de forma secuencial todos los seeders configurados sobre el contexto <see cref="RealStateDbContext"/>.
    /// </summary>
    public async Task SeedRealStateDatabase(RealStateDbContext context)
    {
        foreach (ISeeder<RealStateDbContext> seeder in seedersRealState)
        {
            await seeder.Seed(context);
            await context.SaveChangesAsync();
        }
    }
}