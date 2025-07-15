using AviationFactory.Entities.Products.Planes;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services;

// Implements singleton
public sealed class ProductManager : IProductManager
{
    private readonly List<BasePlane> _planes;
    
    public static ProductManager Instance => _instance;

    private ProductManager()
    {
        _planes = [];    
    }

    static ProductManager()
    {
        _instance = new ProductManager();
    }
    
    private static readonly ProductManager _instance;
    
    public List<BasePlane> GetAllPlanes()
    {
        return _planes;
    }
}