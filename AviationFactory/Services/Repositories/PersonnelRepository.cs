using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Repositories;

public sealed class PersonnelRepository : IPersonnelRepository
{
    private readonly List<BaseEmployee> _employees;
    
    private static readonly PersonnelRepository _instance;
    
    private PersonnelRepository()
    {
        _employees = new List<BaseEmployee>();
    }

    static PersonnelRepository()
    {
        _instance = new PersonnelRepository();
    }
    
    public static PersonnelRepository Instance => _instance;
    
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

    public BaseEmployee? GetEmployee(Guid employeeId)
    {
        return _employees.SingleOrDefault(e => e.Id == employeeId);
    }
}