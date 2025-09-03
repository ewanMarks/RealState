using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Owners.Commands.Desactivate;
using RealState.Contracts.Request.Owners.Deactivate;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Owners;

internal sealed class Deactivate : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Tags.Owner}/{nameof(Deactivate)}", async ([FromBody] DeactivateOwnerRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            var command = request.Adapt<DeactivateOwnerCommand>();
            Result<Guid> result = await sender.Send(command, ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Owner)
        .RequireAuthorization();
    }
}
