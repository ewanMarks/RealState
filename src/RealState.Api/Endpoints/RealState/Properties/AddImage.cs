using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.PropertyImages.Commands;
using RealState.Contracts.Request.Properties.AddImage;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class AddImage : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Property}/{nameof(AddImage)}", async ([FromBody] AddPropertyImageRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            AddPropertyImageCommand command = request.Adapt<AddPropertyImageCommand>();
            Result<Guid> result = await sender.Send(command, ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .RequireAuthorization();
    }
}