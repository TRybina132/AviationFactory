using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Products.Helicopter;

// Base class for helicopter
public class BaseHelicopter : BaseProduct
{
    public string RotorType { get; set; }
    public double MaxAltitude { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxTakeoffWeight { get; set; }
    
    // Maximum distance the helicopter can travel without refueling
    public double Range { get; set; }
    
    public string EngineType { get; set; }
    
    public HelicopterType Type { get; set; }
}