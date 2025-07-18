using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions;

public interface IProductUnitManager
{
    List<ProductUnitViewModel> GetProductsTestedInLab(
        Guid labId, 
        DateTime startTime,
        DateTime endTime,
        ProductType? productType = null);
}