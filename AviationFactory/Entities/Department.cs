namespace AviationFactory.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ManagerId { get; set; }
    public List<Guid> BrigadesIds { get; set; }
}