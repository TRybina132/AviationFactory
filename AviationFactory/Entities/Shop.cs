namespace AviationFactory.Entities;

// Цех
public class Shop
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ManagerId { get; set; }
    public List<Guid> DepartmentsIds { get; set; }
}