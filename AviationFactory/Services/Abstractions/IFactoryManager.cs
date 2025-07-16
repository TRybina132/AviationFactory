using AviationFactory.Models;

namespace AviationFactory.Services.Abstractions;

public interface IFactoryManager
{
    List<DepartmentViewModel> GetDepartments(Guid shopId);  
}