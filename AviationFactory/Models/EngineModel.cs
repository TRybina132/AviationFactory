using AviationFactory.Models.Enums;

namespace AviationFactory.Models;

public class EngineModel
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public EngineType Type { get; set; }
    public double Power { get; set; }
}