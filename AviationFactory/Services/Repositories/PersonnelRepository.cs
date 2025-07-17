using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Repositories;

public sealed class PersonnelRepository : IPersonnelRepository
{
    private readonly List<BaseEmployee> _employees;
    private readonly List<Brigade> _brigades;
    
    private static readonly PersonnelRepository _instance;
    
    private PersonnelRepository()
    {
        _employees = new List<BaseEmployee>();
        _brigades = [];
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

    public List<BaseEmployee> GetEmployees(List<Guid> employeeIds)
    {
        return _employees.Where(x => employeeIds.Contains(x.Id)).ToList();
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

    public Brigade? GetBrigade(Guid brigadeId)
    {
        return _brigades.SingleOrDefault(b => b.Id == brigadeId);
    }

    public List<Brigade> GetBrigadesForDepartment(Guid departmentId)
    {
        return _brigades.Where(b => b.DepartmentId == departmentId)
            .ToList();
    }
}