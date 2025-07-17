using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ManufacturingStep> GetManufacturingSteps(Guid productId)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null)
        {
            return [];
        }
        
        return _productRepository.GetManufacturingSteps(product.ManufacturingStepsIds);
    }

    public List<BaseProduct> GetProductsAssembledInShop(Guid shopId, ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.ShopId == shopId && p.ProductType == type);
        
        return products;
    }

    public List<BaseProduct> GetProductsAssembledInDepartment(Guid departmentId, ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.DepartmentId == departmentId && p.ProductType == type);
        
        return products;
    }

    public List<BaseProduct> GetProducts(ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.ProductType == type);
        
        return products;
    }
}