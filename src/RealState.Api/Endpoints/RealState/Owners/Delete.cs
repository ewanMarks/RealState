using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Owners.Commands.Delete;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Owners;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Tags.Owner}/{nameof(Delete)}", async ([FromQuery] Guid id, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DeleteOwnerCommand(id);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Owner)
        .RequireAuthorization();
    }
}
