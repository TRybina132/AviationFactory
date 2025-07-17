using AviationFactory.Entities.Products;
using AviationFactory.Entities.Products.Helicopter;
using AviationFactory.Entities.Products.Missiles;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Models;

namespace AviationFactory.Services.Abstractions;

public interface IProductRepository
{
    List<BasePlane> GetAllPlanes();
    List<BaseHelicopter> GetAllHelicopters();
    List<BaseMissile> GetAllMissiles();
    List<BaseProduct> GetShopProducts(Guid shopId);
    List<BaseProduct> GetDepartmentProducts(Guid departmentId);
    List<ProductUnit> GetAssembledProducts(Guid shopId, DateTime startTime, DateTime endTime);
    BaseProduct? GetProduct(Guid productId);
    List<ManufacturingStep> GetManufacturingSteps(List<Guid> stepIds);
}