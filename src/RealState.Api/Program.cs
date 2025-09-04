using RealState.Api;
using RealState.Application;
using RealState.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Referencias de conveniencia
IServiceCollection services = builder.Services;
IConfigurationManager configuration = builder.Configuration;
IHostEnvironment environment = builder.Environment;

// Cargar configuraci�n base y espec�fica por ambiente
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Registro de servicios por capas (Infrastructure - Application - Api/Presentation)
services
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddPresentation(configuration);

// Construir la aplicaci�n
WebApplication app = builder.Build();

// Configurar el pipeline de middlewares y endpoints de la capa de presentaci�n
app.UsePresentation(configuration);

// Inicializaci�n de la infraestructura (migraciones/seeders si aplica)
await app.Services.UseInfrastructure();

// Ejecutar la aplicaci�n
await app.RunAsync();

// Clase parcial para habilitar pruebas de integraci�n (WebApplicationFactory<TEntryPoint>)
public partial class Program;
