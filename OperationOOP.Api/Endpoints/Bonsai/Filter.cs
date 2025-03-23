using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints.Bonsai;

public class Filter : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/bonsai/carelevel/{level}", ([FromServices] IDatabase db, string level) =>
        {
            if (!Enum.TryParse<CareLevel>(level, true, out var parsedLevel))
            {
                return Results.BadRequest("Invalid care level");
            }

            var filtered = db.Bonsais
                .Where(b => b.CareLevel == parsedLevel)
                .ToList();

            return Results.Ok(filtered);
        });

        app.MapGet("/api/bonsai/search", ([FromServices] IDatabase db, [FromQuery] string name) =>
        {
            var result = db.Bonsais
                .Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Results.Ok(result);
        });
    }
}