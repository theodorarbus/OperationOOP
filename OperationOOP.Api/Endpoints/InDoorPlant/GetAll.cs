namespace OperationOOP.Api.Endpoints.InDoorPlant;

public class GetAllIndoorPlants : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/indoorplants", Handle)
        .WithSummary("Hämta alla inomhusväxter");

    // Response DTO
    public record Response(
        int Id,
        string Name,
        string Species,
        DateTime LastWatered,
        bool LowMaintainance,
        LightRequirement Light
    );

    // Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.InDoorPlants
            .Select(plant => new Response(
                Id: plant.Id,
                Name: plant.Name,
                Species: plant.Species,
                LastWatered: plant.LastWatered,
                LowMaintainance: plant.LowMaintainance,
                Light: plant.Light
            )).ToList();
    }
}