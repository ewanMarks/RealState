using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Properties.Commands.Update;
using RealState.Contracts.Request.Properties.Update;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut($"{Tags.Property}/{nameof(Update)}", async ([FromBody] UpdatePropertyRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            UpdatePropertyCommand command = request.Adapt<UpdatePropertyCommand>();
            Result<Guid> result = await sender.Send(command, ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .RequireAuthorization();
    }
}