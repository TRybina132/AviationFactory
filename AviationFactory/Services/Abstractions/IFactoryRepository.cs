using AviationFactory.Entities;

namespace AviationFactory.Services.Abstractions;

public interface IFactoryRepository
{   
    List<Department> GetDepartments(Guid shopId);
    List<Shop> GetShops();
    Shop? GetShop(Guid shopId);
}