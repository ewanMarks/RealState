using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Seeders.RealState;

public class PropertySeeder : ISeeder<RealStateDbContext>
{
    private const string House1001 = "H-1001";
    private const string Apt2001 = "A-2001";
    private const string Lot3001 = "L-3001";

    public async Task Seed(RealStateDbContext context)
    {
        if (await context.Properties.AnyAsync())
        {
            return;
        }

        var ana = await context.Owners.AsNoTracking().FirstAsync(o => o.Name == "Ana Orozco");
        var laura = await context.Owners.AsNoTracking().FirstAsync(o => o.Name == "Laura Jaimes");
        var juan = await context.Owners.AsNoTracking().FirstAsync(o => o.Name == "Juan Hernandez");

        var properties = new List<Property>
        {
            new("Casa Campestre", "Vereda El Retiro", 450_000_000m, House1001, 2020, ana.Id),
            new("Apto Chicó", "Calle 94 #11", 650_000_000m, Apt2001, 2019, laura.Id),
            new("Lote Norte", "Km 12 Vía al Mar", 120_000_000m, Lot3001, 2024, juan.Id),
        };

        await context.Properties.AddRangeAsync(properties);
    }
}
