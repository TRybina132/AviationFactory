namespace AviationFactory.Entities.Products.Missiles;

// Air to air missile
public class AamMissile : BaseMissile
{
    public double Speed { get; set; }
    public double Maneuverability { get; set; }
    public string TargetingMode { get; set; }
}
