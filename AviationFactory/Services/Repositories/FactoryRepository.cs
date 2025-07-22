using AviationFactory.Entities;
using AviationFactory.Services.Abstractions;
using AviationFactory.Services.Abstractions.Repositories;

namespace AviationFactory.Services.Repositories;

// Repository for managing factory structure
public class FactoryRepository : IFactoryRepository
{
    private readonly List<Shop> _shops;
    private readonly List<Department> _departments;
    
    private static readonly FactoryRepository _instance;
    
    private FactoryRepository()
    {
        _shops = new List<Shop>();
        _departments = new List<Department>();
    }

    static FactoryRepository()
    {
        _instance = new FactoryRepository();
    }
    
    public static FactoryRepository Instance => _instance;
    
    public List<Department> GetDepartments(Guid shopId)
    {
        return _departments.Where(d => d.ShopId == shopId)
            .ToList();
    }

    public List<Shop> GetShops()
    {
        return _shops;
    }

    public Shop? GetShop(Guid shopId)
    {
        return _shops.SingleOrDefault(s => s.Id == shopId);
    }

    public bool CreateDepartment(Department department)
    {
        var existing = _departments
            .SingleOrDefault(d => d.Name == department.Name);

        if (existing != null)
        {
            return false;
        }
        
        _departments.Add(department);
        return true;
    }

    public bool CreateShop(Shop shop)
    {
        var existing = _shops
            .SingleOrDefault(s => s.Name == shop.Name);

        if (existing != null)
        {
            return false;
        }
        
        _shops.Add(shop);
        return true;
    }
}