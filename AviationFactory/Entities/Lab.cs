namespace AviationFactory.Entities;

public class Lab
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Guid>? Departments { get; set; }
}