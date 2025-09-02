using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Seeders.RealState;

public class OwnerSeeder : ISeeder<RealStateDbContext>
{
    public async Task Seed(RealStateDbContext context)
    {
        if (await context.Owners.AnyAsync())
        {
            return;
        }

        context.Owners.AddRange(new List<Owner>
        {
            new("Ana Orozco", "Calle 10 #5-20", null, new DateOnly(1985, 6, 15)),
            new("Laura Jaimes", "Cra 7 #20-15", null, new DateOnly(1990, 3, 30)),
            new("Juan Hernandez", "Av. 80 #45-12", null, new DateOnly(1978, 11,  2))
        });
    }
}
