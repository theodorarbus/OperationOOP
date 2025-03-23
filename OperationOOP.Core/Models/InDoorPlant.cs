namespace OperationOOP.Core.Models;

public class InDoorPlant : Plant
{
    public bool LowMaintainance { get; set; }
    public LightRequirement Light { get; set; }
}

public enum LightRequirement
{
    Low,
    Medium,
    High
}