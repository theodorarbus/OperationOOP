using Microsoft.AspNetCore.Mvc;
namespace OperationOOP.Api.Endpoints.Plant;

public class Search : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("SearchPlant", ([FromServices] IDatabase db, [FromQuery] string name) =>
        {
            var bonsaiMatches = db.Bonsais
                .Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                {
                    Type = "Bonsai",
                    b.Id,
                    b.Name,
                    b.Species,
                    b.LastWatered
                });

            var indoorMatches = db.InDoorPlants
                .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(p => new
                {
                    Type = "IndoorPlant",
                    p.Id,
                    p.Name,
                    p.Species,
                    p.LastWatered
                });
            
            var outdoorMatches = db.OutDoorPlants
                .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(p => new
                {
                    Type = "OutDoorPlant",
                    p.Id,
                    p.Name,
                    p.Species,
                    p.LastWatered
                });

            var results = bonsaiMatches
                .Concat(indoorMatches)
                .Concat(outdoorMatches)
                .ToList();

            return Results.Ok(results);
        });
    }
}