using Mapster;
using RealState.Application.UseCase.Owners.DTOs;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Application.UseCase.Owners.Queries.GetAll;

public sealed class GetAllOwnersQueryMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Owner, OwnerListItemDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Photo, src => src.Photo)
            .Map(dest => dest.Birthday, src => src.Birthday)
            .Map(dest => dest.CreatedOn, src => src.CreatedOn);
    }
}