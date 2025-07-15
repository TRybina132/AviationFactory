using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Products.Planes;

public abstract class BasePlane : BaseProduct
{
    public List<EngineModel> Engines { get; set; }
    public string WingType { get; set; }
    public double MaxRange { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxTakeoffWeight { get; set; }
    public PlaneType PlaneType { get; set; }
}