namespace AviationFactory.Entities.Products.Missiles;

public class BallisticMissile : BaseMissile
{
    public double MaximumAltitude { get; set; }
    public double Speed { get; set; } 
    public string WarheadType { get; set; }
}
