namespace RealState.Api.Extensions;

/// <summary>
/// Métodos de extensión para configurar middlewares en el pipeline de la aplicación.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Habilita Swagger y su interfaz gráfica (Swagger UI) en la aplicación.
    /// </summary>
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}