using AviationFactory.Entities;
using AviationFactory.Models;

namespace AviationFactory.Services.Abstractions;

public interface IFactoryManager
{
    List<DepartmentViewModel> GetDepartments(Guid shopId);  
    List<ShopViewModel> GetShops();
    List<Brigade> GetBrigadesForDepartment(Guid departmentId);
    List<BrigadeViewModel> GetBrigadesForShop(Guid shopId);
}