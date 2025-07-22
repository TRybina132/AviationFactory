namespace AviationFactory.Entities.Products.Planes;

public class FighterPlane : BasePlane
{
    public List<string> PrimaryRole { get; set; }
    public double CombatRadius { get; set; }
    public double ArmamentCapacity { get; set; }
    public bool SupercruiseCapable { get; set; }
    public List<string> Armament { get; set; }
}