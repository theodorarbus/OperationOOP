using OutdoorPlantModel = OperationOOP.Core.Models.OutDoorPlant;

namespace OperationOOP.Api.Endpoints.OutdoorPlant;

public class CreateOutdoorPlant : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/outdoorplants", Handle)
        .WithSummary("Lägg till en ny utomhusväxt");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        bool SurvivesFrost,
        OutDoorPlantCategory Category
    );

    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var plant = new OutdoorPlantModel
        {
            Id = db.OutDoorPlants.Any() ? db.OutDoorPlants.Max(p => p.Id) + 1 : 1,
            Name = request.Name,
            Species = request.Species,
            AgeYears = request.AgeYears,
            LastWatered = request.LastWatered,
            SurvivesFrost = request.SurvivesFrost,
            Category = request.Category
        };

        db.OutDoorPlants.Add(plant);

        return TypedResults.Ok(new Response(plant.Id));
    }
}