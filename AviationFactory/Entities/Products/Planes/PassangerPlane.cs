namespace AviationFactory.Entities.Products.Planes;

public class PassengerPlane : BasePlane
{
    public int PassengerCapacity { get; set; }
    public double CargoCapacity { get; set; }
    public double MaxPalletNumberUnderfloor { get; set; }
    public double WaterVolume { get; set; }
}