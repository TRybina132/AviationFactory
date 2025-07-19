using AviationFactory.Entities.Products;

namespace AviationFactory.Models.Stages;

public class ManufacturingState
{
    private readonly ProductUnit _productUnit;
    public List<string> CanTransition { get; init; }
    
    public ManufacturingState(ProductUnit productUnit, List<string> canTransition, string name)
    {
        _productUnit = productUnit;
        CanTransition = canTransition;
        Name = name;
        StartDate = DateTime.Today;
    }
    
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public void TransitionTo(ManufacturingStep nextStep)
    {
        if (CanTransition.Contains(nextStep.Name))
        {
            EndDate = DateTime.Now;
            _productUnit.SetState(new ManufacturingState(_productUnit, CanTransition, nextStep.Name));
        }
    }
}

public class ManufacturingStage
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}