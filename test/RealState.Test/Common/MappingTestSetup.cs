using Mapster;
using NUnit.Framework;
using RealState.Application.UseCase.Owners.Commands.Create;
using RealState.Application.UseCase.Owners.Queries.GetAll;
using RealState.Application.UseCase.Properties.Commands.Create;
using RealState.Application.UseCase.Properties.Queries.GetAll;
using RealState.Application.UseCase.PropertyImages.Commands;

[SetUpFixture]
public class MappingTestSetup
{
    [OneTimeSetUp]
    public void RegisterMappings()
    {
        var cfg = TypeAdapterConfig.GlobalSettings;

        // Owners
        new CreateOwnerCommandMappingConfiguration().Register(cfg);
        new GetAllOwnersQueryMappingConfiguration().Register(cfg);

        // Properties
        new CreatePropertyBuildingCommandMappingConfiguration().Register(cfg);
        new AddPropertyImageCommandMappingConfiguration().Register(cfg);
        new GetAllPropertiesQueryMappingConfiguration().Register(cfg);

        cfg.Compile();
    }
}