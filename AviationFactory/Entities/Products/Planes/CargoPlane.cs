namespace AviationFactory.Entities.Products.Planes;

public class CargoPlane : BasePlane
{
    public double LoadCapacity { get; set; }
    public double Height { get; set; }
    public string DoorFormFactor { get; set; }
}