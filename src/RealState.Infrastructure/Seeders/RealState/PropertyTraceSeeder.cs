using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Seeders.RealState;

public class PropertyTraceSeeder : ISeeder<RealStateDbContext>
{
    public async Task Seed(RealStateDbContext context)
    {
        if (await context.PropertyTraces.AnyAsync()) 
        {
            return;
        }

        var h1001 = await context.Properties.AsNoTracking().FirstAsync(p => p.CodeInternal == "H-1001");
        var a2001 = await context.Properties.AsNoTracking().FirstAsync(p => p.CodeInternal == "A-2001");

        var traces = new List<PropertyTrace>
        {
            new(h1001.Id, DateTime.UtcNow.AddMonths(-6), "Venta inicial", 430_000_000m, 12_000_000m),
            new(h1001.Id, DateTime.UtcNow.AddMonths(-3), "Ajuste de precio", 440_000_000m, 0m),
            new(a2001.Id, DateTime.UtcNow.AddMonths(-10),"Venta", 620_000_000m, 15_000_000m),
        };

        await context.PropertyTraces.AddRangeAsync(traces);
    }
}
