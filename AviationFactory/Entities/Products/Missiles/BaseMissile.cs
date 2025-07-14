namespace AviationFactory.Entities.Products.Missiles;

public class BaseMissile : BaseProduct
{
    public double Range { get; set; }
    public double Payload { get; set; }
    public string GuidanceSystem { get; set; }
}
