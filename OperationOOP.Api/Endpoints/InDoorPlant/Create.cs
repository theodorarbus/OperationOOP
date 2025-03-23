using InDoorPlantModel = OperationOOP.Core.Models.InDoorPlant;

namespace OperationOOP.Api.Endpoints.InDoorPlant;

public class CreateIndoorPlant : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/indoorplants", Handle)
        .WithSummary("Lägg till en ny inomhusväxt");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        bool LowMaintainance,
        LightRequirement Light
    );

    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var plant = new InDoorPlantModel
        {
            Id = db.InDoorPlants.Any() ? db.InDoorPlants.Max(p => p.Id) + 1 : 1,
            Name = request.Name,
            Species = request.Species,
            AgeYears = request.AgeYears,
            LastWatered = request.LastWatered,
            LowMaintainance = request.LowMaintainance,
            Light = request.Light
        };

        db.InDoorPlants.Add(plant);

        return TypedResults.Ok(new Response(plant.Id));
    }
}