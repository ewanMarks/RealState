using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.PropertyImages.Commands;
using RealState.Contracts.Request.Properties.AddImage;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class UploadImage : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Property}/{nameof(UploadImage)}", async ([FromForm] UploadPropertyImageRequest request, [FromServices] IWebHostEnvironment env, [FromServices] ISender sender, CancellationToken ct) =>
        {
            if (request.File is null || request.File.Length == 0)
            {
                return Results.BadRequest("El archivo es obligatorio.");
            }

            string webRoot = string.IsNullOrWhiteSpace(env.WebRootPath)
                ? Path.Combine(AppContext.BaseDirectory, "wwwroot")
                : env.WebRootPath;

            var folder = Path.Combine(webRoot, "uploads", "properties", request.IdProperty.ToString());
            Directory.CreateDirectory(folder);

            var extension = Path.GetExtension(request.File.FileName);
            var fileName = $"{Guid.NewGuid():N}{extension}";
            var physicalPath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream, ct);
            }

            var relativePath = $"/uploads/properties/{request.IdProperty}/{fileName}";

            AddPropertyImageCommand command = new AddPropertyImageCommand(
                request.IdProperty,
                relativePath.Replace('\\', '/'),
                request.Enabled
            );

            Result<Guid> result = await sender.Send(command, ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .DisableAntiforgery()
        .RequireAuthorization();
    }
}