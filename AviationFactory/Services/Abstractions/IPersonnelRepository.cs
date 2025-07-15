using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;

namespace AviationFactory.Services.Abstractions;

public interface IPersonnelRepository
{
   List<BaseEmployee> GetAllEmployees(); 
   List<BaseEmployee> GetEmployeesFromDepartment(Guid departmentId);
   List<BaseEmployee> GetEmployeesFromShop(Guid shopId);
   List<TechnicalEmployee> GetTechnicalEmployees();
   List<WorkerEmployee> GetWorkersEmployees();
}