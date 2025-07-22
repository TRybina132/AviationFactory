using AviationFactory.Entities.Products;
using AviationFactory.Entities.Products.Helicopter;
using AviationFactory.Entities.Products.Missiles;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Models;
using AviationFactory.Models.Commands;
using AviationFactory.Models.Enums;
using AviationFactory.Models.Stages;
using AviationFactory.Services.Abstractions;
using AviationFactory.Services.Abstractions.Managers;
using AviationFactory.Services.Abstractions.Repositories;

namespace AviationFactory.Services.Managers;

// Manager for performing actions with product units
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

    public Guid? CreateProductUnit(CreateProductUnitCommand command)
    {
        var product = _productRepository.GetProduct(command.ProductId);
        if (product == null)
        {
            return null; // Product not found
        }
        
        var productUnit = new ProductUnit
        {
            Id = Guid.NewGuid(),
            ProductId = command.ProductId,
            ProductType = product.ProductType,
            ManufactureDate = DateTime.Now,
            ShopId = command.ShopId,
            TestingStages = new List<TestingStage>()
        };
        
        if (product is BasePlane plane)
        {
            productUnit.SerialNumber = $"PL-{plane.ModelName}-{GetLast4Characters(plane.Id)}";
        }
        else if (product is BaseHelicopter helicopter)
        {
            productUnit.SerialNumber = $"HC-{helicopter.ModelName}-{DateTime.Now:yyyyMMddHHmmss}-{GetLast4Characters(helicopter.Id)}";
        }
        else if (product is BaseMissile missile)
        {
            productUnit.SerialNumber = $"MS-{missile.ModelName}-{DateTime.Now:yyyyMMddHHmmss}-{GetLast4Characters(missile.Id)}";
        }
        else
        {
            productUnit.SerialNumber = $"{product.ModelName}-{DateTime.Now:yyyyMMddHHmmss}-{GetLast4Characters(product.Id)}";
        }
        
        if (!_productRepository.CreateProductUnit(productUnit))
        {
            return null; // Failed to create product unit
        }
        
        return productUnit.Id;
    }

    public bool AddTestingStageToProductUnit(Guid productUnitId, TestingStage testingStage)
    {
        var unit = _productRepository.GetProductUnit(productUnitId);
        if (unit == null)
        {
            return false; // Product unit not found
        }

        unit.TestingStages ??= [];
        unit.TestingStages.Add(testingStage);
        
        return true;
    }

    public bool MoveProductUnitToNextStage(Guid productUnitId, Guid nextStepId)
    {
        var productUnit = _productRepository.GetProductUnit(productUnitId);
        if (productUnit == null)
        {
            return false;
        }

        var nextStep = _productRepository.GetManufacturingSteps(new List<Guid> { nextStepId }).FirstOrDefault();
        if (nextStep == null)
        {
            return false;
        }

        productUnit.MoveToNextStep(nextStep);
        return true;
    }

    public ProductUnit? GetProductUnitById(Guid productUnitId)
    {
        return _productRepository.GetProductUnit(productUnitId);
    }

    private string GetLast4Characters(Guid productId)
    {
        var guidString = productId.ToString("N");
        return guidString.Substring(guidString.Length - 4);
    }
}