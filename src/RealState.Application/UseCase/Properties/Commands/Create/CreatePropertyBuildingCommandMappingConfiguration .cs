using Mapster;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Application.UseCase.Properties.Commands.Create;

public sealed class CreatePropertyBuildingCommandMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePropertyBuildingCommand, Property>()
            .ConstructUsing(src => new Property(
                src.Name,
                src.Address,
                src.Price,
                src.CodeInternal,
                src.Year,
                src.IdOwner
            ));
    }
}