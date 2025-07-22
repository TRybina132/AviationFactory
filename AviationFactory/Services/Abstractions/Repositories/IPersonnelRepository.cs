using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;

namespace AviationFactory.Services.Abstractions.Repositories;

public interface IPersonnelRepository
{
   bool CreateEmployee(BaseEmployee employee);
   bool CreateBrigade(Brigade brigade);
   List<BaseEmployee> GetAllEmployees(); 
   List<BaseEmployee> GetEmployees(List<Guid> employeeIds);
   List<BaseEmployee> GetEmployeesFromDepartment(Guid departmentId);
   List<BaseEmployee> GetEmployeesFromShop(Guid shopId);
   List<TechnicalEmployee> GetTechnicalEmployees();
   List<WorkerEmployee> GetWorkersEmployees();
   BaseEmployee? GetEmployee(Guid employeeId);
   Brigade? GetBrigade(Guid brigadeId);
   List<Brigade> GetBrigadesForDepartment(Guid departmentId);
}