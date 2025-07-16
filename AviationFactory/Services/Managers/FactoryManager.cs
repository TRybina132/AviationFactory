using AviationFactory.Models;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Managers;

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
}