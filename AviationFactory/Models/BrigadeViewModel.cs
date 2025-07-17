using AviationFactory.Entities.Personnel;

namespace AviationFactory.Models;

public class BrigadeViewModel
{
    public Guid Id { get; set; }
    public BaseEmployee? Foreman { get; set; }
    public Guid DepartmentId { get; set; }
    public List<BaseEmployee> Members { get; set; }
}