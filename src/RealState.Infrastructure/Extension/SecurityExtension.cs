using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Common.Security;
using RealState.Infrastructure.Security.Models;
using RealState.Infrastructure.Security;

namespace RealState.Infrastructure.Extension;

public static class SecurityExtension
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddSingleton<IPasswordHasher, PasswordHasherPbkdf2>();
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        return services;
    }
}
