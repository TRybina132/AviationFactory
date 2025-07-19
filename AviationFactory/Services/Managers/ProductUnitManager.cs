using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Abstractions;
using AviationFactory.Services.Abstractions.Managers;
using AviationFactory.Services.Abstractions.Repositories;

namespace AviationFactory.Services.Managers;

public class ProductUnitManager : IProductUnitManager
{
    private readonly IProductRepository _productRepository;

    public ProductUnitManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductUnitViewModel> GetProductsTestedInLab(
        Guid labId, 
        DateTime startTime,
        DateTime endTime,
        ProductType? productType = null)
    {
        Func<ProductUnit, bool> query =
                productType != null ?
            (pu => pu.TestingStages.Any(t => t.LabId == labId &&
                                            t.StartDate >= startTime &&
                                            t.EndDate <= endTime))
            :
            (pu => pu.ProductType == productType && pu.TestingStages.Any(t => t.LabId == labId &&
                                             t.StartDate >= startTime &&
                                             t.EndDate <= endTime));
        
        var productUnits = _productRepository.GetProductUnits(query);

        var result = new List<ProductUnitViewModel>();
        foreach (var productUnit in productUnits)
        {
            var product = _productRepository.GetProduct(productUnit.ProductId);
            if (product != null)
            {
                result.Add(new ProductUnitViewModel
                {
                    Id = productUnit.Id,
                    SerialNumber = productUnit.SerialNumber,
                    ManufactureDate = productUnit.ManufactureDate,
                    Model = product.ModelName,
                    ProductId = productUnit.ProductId,
                    ProductType = product.ProductType,
                });
            }
        }
        
        return result;
    }
}