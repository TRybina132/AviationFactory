using AviationFactory.Entities.Products;

namespace AviationFactory.Models.Stages;

// State of product unit
public class ManufacturingState
{
    private readonly ProductUnit _productUnit;
    public List<Guid> CanTransition { get; init; }
    
    public ManufacturingState(ProductUnit productUnit, List<Guid> canTransition, string name, bool isFinal)
    {
        _productUnit = productUnit;
        CanTransition = canTransition;
        Name = name;
        StartDate = DateTime.Today;
        IsFinal = isFinal;
    }
    
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsFinal { get; set; }

    public void TransitionTo(ManufacturingStep nextStep)
    {
        if (IsFinal)
        {
            _productUnit.Complete();
        }
        
        // Check if can transition to next stage
        if (CanTransition.Contains(nextStep.Id))
        {
            EndDate = DateTime.Now;
            _productUnit.SetState(new ManufacturingState(_productUnit, nextStep.CanTransition, nextStep.Name, nextStep.IsFinal));
        }
    }
}

public class ManufacturingStage
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}