using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Personnel;

// Base abstract class for all employees
public abstract class BaseEmployee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
    public Guid? TeamId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? ShopId { get; set; }
    public EmployeeType Type { get; set; }
}