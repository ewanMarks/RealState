using Mapster;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Application.UseCase.Owners.Commands.Update;

public sealed class UpdateOwnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(UpdateOwnerCommand request, Owner owner), Owner>()
            .Ignore(dest => dest.Properties)
            .Map(dest => dest.Name, src => src.request.Name)
            .Map(dest => dest.Address, src => src.request.Address)
            .Map(dest => dest.Photo, src => src.request.Photo)
            .Map(dest => dest.Birthday, src => src.request.Birthday)
            .Map(dest => dest.LastModifiedOn, src => DateTime.UtcNow);
    }
}