namespace OperationOOP.Core.Models;

public abstract class Plant : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }

}