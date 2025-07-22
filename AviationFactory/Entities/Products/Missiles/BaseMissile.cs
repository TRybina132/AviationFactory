namespace AviationFactory.Entities.Products.Missiles;


// Base class for missile
public abstract class BaseMissile : BaseProduct
{
    public double Range { get; set; }
    public double Payload { get; set; }
    public string GuidanceSystem { get; set; }
}
