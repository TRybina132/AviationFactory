namespace AviationFactory.Entities.Products.Helicopter;

public class AttackHelicopter : BaseHelicopter
{
    public List<string> WeaponSystems { get; set; }
    public string ArmorLevel { get; set; }
    public List<string> Avionics { get; set; }
}