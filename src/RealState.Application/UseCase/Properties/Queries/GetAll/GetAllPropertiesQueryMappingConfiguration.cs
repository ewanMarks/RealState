using Mapster;
using RealState.Application.UseCase.Properties.DTOs;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Application.UseCase.Properties.Queries.GetAll;

public sealed class GetAllPropertiesQueryMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Property, PropertyListItemDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.IdOwner, src => src.IdOwner)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.CodeInternal, src => src.CodeInternal)
            .Map(dest => dest.Year, src => src.Year)
            .Map(dest => dest.CreatedOn, src => src.CreatedOn);
    }
}
