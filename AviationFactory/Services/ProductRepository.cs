using AviationFactory.Entities.Products;
using AviationFactory.Entities.Products.Helicopter;
using AviationFactory.Entities.Products.Missiles;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services;

// Implements singleton
public sealed class ProductRepository : IProductRepository
{
    private readonly List<BaseProduct> _products;
    private readonly List<ProductUnit> _assembledProducts;
    
    public static ProductRepository Instance => _instance;

    private ProductRepository()
    {
        _products = [];    
        _assembledProducts = [];
    }

    static ProductRepository()
    {
        _instance = new ProductRepository();
    }
    
    private static readonly ProductRepository _instance;
    
    public List<BasePlane> GetAllPlanes()
    {
        List<BasePlane> planes = _products
            .Where(p => p.ProductType == ProductType.Plane)
            .Select(p => p as BasePlane)
            .Where(p => p != null)
            .ToList()!;
        
        return planes;
    }

    public List<BaseHelicopter> GetAllHelicopters()
    {
        List<BaseHelicopter> helicopter = _products
            .Where(p => p.ProductType == ProductType.Helicopter)
            .Select(p => p as BaseHelicopter)
            .Where(p => p != null)
            .ToList()!;
        
        return helicopter;
    }

    public List<BaseMissile> GetAllMissiles()
    {
        List<BaseMissile> missile = _products
            .Where(p => p.ProductType == ProductType.Missile)
            .Select(p => p as BaseMissile)
            .Where(p => p != null)
            .ToList()!;
        
        return missile;
    }

    public List<BaseProduct> GetShopProducts(Guid shopId)
    {
        return _products.Where(p => p.ShopId == shopId).ToList();
    }

    public List<BaseProduct> GetDepartmentProducts(Guid departmentId)
    {
        return _products.Where(p => p.DepartmentId == departmentId).ToList();
    }

    public List<ProductUnit> GetAssembledProducts(Guid shopId, DateTime startTime, DateTime endTime)
    {
        return _assembledProducts.Where(p => p.ShopId == shopId
                                             && p.ManufactureDate >= startTime
                                             && p.ManufactureDate <= endTime).ToList();
    }
}