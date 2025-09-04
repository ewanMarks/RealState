using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RealState.Api.Extensions;
using System.Reflection;

namespace RealState.Api;

/// <summary>
/// Métodos de extensión para registrar y configurar los servicios 
/// y middlewares de la capa de presentación (API).
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registra en el contenedor de dependencias todos los servicios necesarios 
    /// para la capa de presentación (controllers, endpoints, swagger, CORS, etc.).
    /// </summary>
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddAuthJwt(configuration);
        services.AddSwaggerGenWithAuth();
        services.AddEndpointsApiExplorer();
        services.AddHealthChecks();
        services.AddControllers();
        services.AddProblemDetails();
        services.AddEndpoints(Assembly.GetExecutingAssembly());
        services.AddCorsConfiguration(configuration);
        services.AddHttpContextAccessor();

        return services;
    }

    /// <summary>
    /// Configura el pipeline de middlewares para la capa de presentación.
    /// </summary>
    public static WebApplication UsePresentation(this WebApplication app, IConfiguration configuration)
    {
        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        app.UseCorsConfiguration(configuration);
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapEndpoints();
        app.MapOpenApi();
        app.UseSwaggerWithUi();

        app.MapHealthChecks("health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return app;
    }
}
