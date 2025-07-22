namespace AviationFactory.Models;

// Represent part of work that needs to be done to produce product
public class ManufacturingStep
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    // Next steps of production after completion of this step
    public List<Guid> CanTransition { get; set; }
    public bool IsFinal { get; set; }
}