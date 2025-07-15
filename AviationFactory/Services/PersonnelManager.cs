using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services;

public sealed class PersonnelManager : IPersonnelManager
{
    private readonly List<BaseEmployee> _employees;
    
    private static readonly PersonnelManager _instance;
    
    private PersonnelManager()
    {
        _employees = new List<BaseEmployee>();
    }

    static PersonnelManager()
    {
        _instance = new PersonnelManager();
    }
    
    public static PersonnelManager Instance => _instance;
    
    public List<BaseEmployee> GetAllEmployees()
    {
        return _employees;
    }

    public List<BaseEmployee> GetEmployeesFromDepartment(Guid departmentId)
    {
        return _employees.Where(e => e.DepartmentId == departmentId)
            .ToList();
    }

    public List<BaseEmployee> GetEmployeesFromShop(Guid shopId)
    {
        return _employees.Where(e => e.ShopId == shopId)
            .ToList();
    }

    public List<TechnicalEmployee> GetTechnicalEmployees()
    {
        return _employees.OfType<TechnicalEmployee>()
            .ToList();
    }

    public List<WorkerEmployee> GetWorkersEmployees()
    {
        return _employees.OfType<WorkerEmployee>()
            .ToList();
    }
}