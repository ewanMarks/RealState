using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.ChangePrice.Commands.Change;
using RealState.Contracts.Request.Properties.ChangePrice;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class ChangePrice : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Property}/{nameof(ChangePrice)}", async ([FromBody] ChangePropertyPriceRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            ChangePropertyPriceCommand command = request.Adapt<ChangePropertyPriceCommand>();
            Result<Guid> result = await sender.Send(command, ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .RequireAuthorization();
    }
}