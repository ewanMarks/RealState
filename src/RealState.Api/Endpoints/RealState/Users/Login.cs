using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Auth.Commands.Login;
using RealState.Application.UseCase.Auth.DTOs;
using RealState.Contracts.Request.Users.Login;
using RealState.Contracts.Response.Users.Login;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Users;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Auth}/{nameof(Login)}", [AllowAnonymous] async ([FromBody] LoginRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            var command = request.Adapt<LoginCommand>();
            Result<AuthResult> result = await sender.Send(command, ct);

            return result.Match(value => Results.Ok(value.Adapt<AuthResponse>()), CustomResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Auth);
    }
}
