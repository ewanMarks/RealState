using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Seeders.RealState;

namespace RealState.Infrastructure.Seeders;

public class SeederManager
{
    private readonly List<ISeeder<RealStateDbContext>> seedersRealState;

    public SeederManager()
    {
        seedersRealState =
        [
            new OwnerSeeder(),
            new PropertySeeder(),
            new PropertyImageSeeder(),
            new PropertyTraceSeeder()
        ];
    }

    public async Task SeedRealStateDatabase(RealStateDbContext context)
    {
        foreach (ISeeder<RealStateDbContext> seeder in seedersRealState)
        {
            await seeder.Seed(context);
            await context.SaveChangesAsync();
        }
    }
}