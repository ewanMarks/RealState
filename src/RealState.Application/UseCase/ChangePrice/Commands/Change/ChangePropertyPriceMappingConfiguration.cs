using Mapster;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Application.UseCase.ChangePrice.Commands.Change;

public sealed class ChangePropertyPriceMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChangePropertyPriceCommand, PropertyTrace>()
            .ConstructUsing(src => new PropertyTrace(
                src.IdProperty,
                DateTime.UtcNow,
                string.IsNullOrWhiteSpace(src.Name) ? "Change Price" : src.Name!,
                src.NewPrice,
                src.Tax ?? 0m
            ));
    }
}