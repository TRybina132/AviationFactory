using AviationFactory.Entities;
using AviationFactory.Models;
using AviationFactory.Services.Abstractions;
using AviationFactory.Services.Abstractions.Managers;
using AviationFactory.Services.Abstractions.Repositories;

namespace AviationFactory.Services.Managers;

// Manager for managing shops and departments of factory
public class FactoryManager : IFactoryManager
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IPersonnelRepository _personnelRepository;
    
    public FactoryManager(IFactoryRepository factoryRepository, IPersonnelRepository personnelRepository)
    {
        _factoryRepository = factoryRepository;
        _personnelRepository = personnelRepository;
    }
    
    public List<DepartmentViewModel> GetDepartments(Guid shopId)
    {
        var departments = _factoryRepository.GetDepartments(shopId);
        var departmentViewModels = new List<DepartmentViewModel>();

        foreach (var department in departments)
        {
            var manager = _personnelRepository.GetEmployee(department.ManagerId);
            var departmentViewModel = new DepartmentViewModel
            {
                Department = department,
                Head = manager
            };
            departmentViewModels.Add(departmentViewModel);
        }

        return departmentViewModels;
    }

    public List<ShopViewModel> GetShops()
    {
        var shops = _factoryRepository.GetShops();
        var shopViewModels = new List<ShopViewModel>();
        
        foreach (var shop in shops)
        {
            var manager = _personnelRepository.GetEmployee(shop.ManagerId);
            var shopViewModel = new ShopViewModel
            {
                Shop = shop,
                Head = manager
            };
            shopViewModels.Add(shopViewModel);
        }
        
        return shopViewModels;
    }

    public List<BrigadeViewModel> GetBrigadesForDepartment(Guid departmentId)
    {
        var brigades = _personnelRepository.GetBrigadesForDepartment(departmentId);
        return GetBrigadesWithEmployees(brigades);
    }

    public List<BrigadeViewModel> GetBrigadesForShop(Guid shopId)
    {
        var shop = _factoryRepository.GetShop(shopId);
        if (shop == null)
        {
            return new List<BrigadeViewModel>();
        }

        var brigades = new List<BrigadeViewModel>();
        foreach (var departmentId in shop.DepartmentsIds)
        {
            var departmentBrigades = _personnelRepository
                .GetBrigadesForDepartment(departmentId);
           
            brigades.AddRange(GetBrigadesWithEmployees(departmentBrigades));
        }
        return brigades;
    }

    private List<BrigadeViewModel> GetBrigadesWithEmployees(List<Brigade> brigades)
    {
        var brigadesViewModels = new List<BrigadeViewModel>();
        foreach (var brigade in brigades)
        {
            var employees = _personnelRepository.GetEmployees(brigade.MembersIds);
            var foreman = _personnelRepository.GetEmployee(brigade.ForemanId);
            var brigadeViewModel = new BrigadeViewModel
            {
                Id = brigade.Id,
                Foreman = foreman,
                DepartmentId = brigade.DepartmentId,
                Members = employees
            };
            brigadesViewModels.Add(brigadeViewModel);
        }
        
        return brigadesViewModels;
    }
}