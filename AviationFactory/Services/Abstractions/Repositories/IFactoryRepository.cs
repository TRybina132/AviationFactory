using AviationFactory.Entities;

namespace AviationFactory.Services.Abstractions.Repositories;

public interface IFactoryRepository
{   
    List<Department> GetDepartments(Guid shopId);
    List<Shop> GetShops();
    Shop? GetShop(Guid shopId);
    bool CreateDepartment(Department department);
    bool CreateShop(Shop shop);
}