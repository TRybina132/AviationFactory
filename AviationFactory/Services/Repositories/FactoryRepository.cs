using AviationFactory.Entities;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Repositories;

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
}