using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Seeders;

public interface ISeeder<in TDbContext> where TDbContext : DbContext
{
    Task Seed(TDbContext context);
}
