using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<InDoorPlant> InDoorPlants { get; set; }
        List<OutDoorPlant> OutDoorPlants { get; set; }

    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<InDoorPlant> InDoorPlants { get; set; } = new List<InDoorPlant>();
        public List<OutDoorPlant> OutDoorPlants { get; set; } = new List<OutDoorPlant>();

    }
}
