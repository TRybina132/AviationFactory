using AviationFactory.Models;

namespace AviationFactory.Services.Abstractions.Managers;

public interface IFactoryManager
{
    List<DepartmentViewModel> GetDepartments(Guid shopId);  
    List<ShopViewModel> GetShops();
    List<BrigadeViewModel> GetBrigadesForDepartment(Guid departmentId);
    List<BrigadeViewModel> GetBrigadesForShop(Guid shopId);
}