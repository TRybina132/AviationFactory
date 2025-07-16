using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;

namespace AviationFactory.Models;

public class DepartmentViewModel
{
    public Department Department { get; set; }
    public BaseEmployee? Head { get; set; }
}