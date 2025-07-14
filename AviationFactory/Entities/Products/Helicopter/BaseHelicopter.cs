namespace AviationFactory.Entities.Products.Helicopter;

public class BaseHelicopter : BaseProduct
{
    public string RotorType { get; set; }
    public double MaxAltitude { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxTakeoffWeight { get; set; }
    
    // Maximum distance the helicopter can travel without refueling
    public double Range { get; set; }
    
    public string EngineType { get; set; }
}