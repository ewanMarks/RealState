using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Properties.Commands.Create;
using RealState.Contracts.Request.Properties.Create;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Property}/{nameof(Create)}", async ([FromBody] CreatePropertyBuildingRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        {
            CreatePropertyBuildingCommand command = request.Adapt<CreatePropertyBuildingCommand>();
            Result<Guid> result = await sender.Send(command, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .RequireAuthorization();
    }
}