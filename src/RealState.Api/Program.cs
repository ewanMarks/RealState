using RealState.Api;
using RealState.Application;
using RealState.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfigurationManager configuration = builder.Configuration;
IHostEnvironment environment = builder.Environment;

configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);


services
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddPresentation(configuration);

WebApplication app = builder.Build();

app.UsePresentation(configuration);

await app.Services.UseInfrastructure();

await app.RunAsync();

public partial class Program;
