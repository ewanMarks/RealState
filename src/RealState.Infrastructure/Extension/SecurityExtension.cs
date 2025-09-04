using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Common.Security;
using RealState.Infrastructure.Security.Models;
using RealState.Infrastructure.Security;

namespace RealState.Infrastructure.Extension;

/// <summary>
/// Métodos de extensión para registrar los servicios de seguridad en el contenedor de dependencias.
/// </summary>
public static class SecurityExtension
{
    /// <summary>
    /// Configura y registra los servicios de seguridad de la aplicación RealState.
    /// </summary>
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddSingleton<IPasswordHasher, PasswordHasherPbkdf2>();
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        return services;
    }
}
