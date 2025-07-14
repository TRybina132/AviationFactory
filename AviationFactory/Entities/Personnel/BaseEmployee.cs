using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Personnel;

public class BaseEmployee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
    public string? TeamId { get; set; }
}