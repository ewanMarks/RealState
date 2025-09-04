using Microsoft.EntityFrameworkCore;

namespace RealState.Infrastructure.Seeders;

public interface ISeeder<in TDbContext> where TDbContext : DbContext
{
    Task Seed(TDbContext context);
}
