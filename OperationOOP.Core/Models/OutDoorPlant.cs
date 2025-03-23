namespace OperationOOP.Core.Models;

public class OutDoorPlant : Plant
{
    public bool SurvivesFrost { get; set; }
    public OutDoorPlantCategory Category { get; set; }
}

public enum OutDoorPlantCategory
{
    Bush,
    Tree,
    Flower
}