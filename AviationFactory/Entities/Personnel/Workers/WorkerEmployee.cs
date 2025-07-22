using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Personnel.Workers;

// Base class for worker employee
public abstract class WorkerEmployee : BaseEmployee
{
    public WorkerEmployeeType Specialization { get; set; }
}