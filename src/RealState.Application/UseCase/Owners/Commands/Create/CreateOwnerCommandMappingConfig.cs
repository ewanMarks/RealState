using Mapster;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Application.UseCase.Owners.Commands.Create;

public sealed class CreateOwnerCommandMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOwnerCommand, Owner>()
            .ConstructUsing(src => new Owner(
                src.Name,
                src.Address,
                src.Photo,
                src.Birthday));
    }
}