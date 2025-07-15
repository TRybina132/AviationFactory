using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Personnel.Workers;

public abstract class WorkerEmployee : BaseEmployee
{
    public WorkerEmployeeType Specialization { get; set; }
}