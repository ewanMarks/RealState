using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Seeders.RealState;

public class PropertyImageSeeder : ISeeder<RealStateDbContext>
{
    public async Task Seed(RealStateDbContext context)
    {
        if (await context.PropertyImages.AnyAsync())
        {
            return;
        }

        var h1001 = await context.Properties.AsNoTracking().FirstAsync(p => p.CodeInternal == "H-1001");
        var a2001 = await context.Properties.AsNoTracking().FirstAsync(p => p.CodeInternal == "A-2001");

        var images = new List<PropertyImage>
        {
            new(h1001.Id, "https://cdn.example.com/images/h1001-1.jpg", true),
            new(h1001.Id, "https://cdn.example.com/images/h1001-2.jpg", true),
            new(a2001.Id, "https://cdn.example.com/images/a2001-1.jpg", false),
        };

        await context.PropertyImages.AddRangeAsync(images);
    }
}
