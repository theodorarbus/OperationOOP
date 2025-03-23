namespace OperationOOP.Api.Endpoints.OutdoorPlant;

public class GetAllOutdoorPlants : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/outdoorplants", Handle)
        .WithSummary("Lista alla utomhusväxter");

    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        bool SurvivesFrost,
        OutDoorPlantCategory Category
    );

    private static List<Response> Handle(IDatabase db)
    {
        return db.OutDoorPlants
            .Select(p => new Response(
                Id: p.Id,
                Name: p.Name,
                Species: p.Species,
                AgeYears: p.AgeYears,
                LastWatered: p.LastWatered,
                SurvivesFrost: p.SurvivesFrost,
                Category: p.Category
            )).ToList();
    }
}