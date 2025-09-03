using Mapster;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Application.UseCase.PropertyImages.Commands;

public sealed class AddPropertyImageCommandMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddPropertyImageCommand, PropertyImage>()
            .ConstructUsing(src => new PropertyImage(
                src.IdProperty,
                src.File,
                src.Enabled
            ));
    }
}