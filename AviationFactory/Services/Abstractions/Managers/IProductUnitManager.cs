using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions.Managers;

public interface IProductUnitManager
{
    List<ProductUnitViewModel> GetProductsTestedInLab(
        Guid labId, 
        DateTime startTime,
        DateTime endTime,
        ProductType? productType = null);
}