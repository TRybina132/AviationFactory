using AviationFactory.Entities.Products.Planes;

namespace AviationFactory.Services.Abstractions;

public interface IProductManager
{
    List<BasePlane> GetAllPlanes();
}