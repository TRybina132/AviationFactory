using AviationFactory.Entities;
using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions;

public interface IFactoryManager
{
    List<DepartmentViewModel> GetDepartments(Guid shopId);  
    List<ShopViewModel> GetShops();
    List<BrigadeViewModel> GetBrigadesForDepartment(Guid departmentId);
    List<BrigadeViewModel> GetBrigadesForShop(Guid shopId);
}