using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Infrastructure.Extension;

namespace RealState.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSecurity(configuration);
        services.AddPersistence(configuration);
        services.AddRepositories(configuration);
        return services;
    }

    public static async Task UseInfrastructure(this IServiceProvider serviceProvider)
    {
        await serviceProvider.RunSeedersAsync();
    }
}
