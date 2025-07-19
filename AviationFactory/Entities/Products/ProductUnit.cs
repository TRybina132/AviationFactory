using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Models.Stages;

namespace AviationFactory.Entities.Products;

// Represents assembled product
public class ProductUnit
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string SerialNumber { get; set; }
    public DateTime ManufactureDate { get; set; }
    public Guid ShopId { get; set; }
    public List<TestingStage> TestingStages { get; set; }
    public List<ManufacturingStage> ManufacturingStages { get; set; } = [];
    
    private ManufacturingState? _state;
    
    public ManufacturingState CurrentState => _state;
    
    public void MoveToNextStep(ManufacturingStep nextStep)
    {
        _state ??= new ManufacturingState(this, nextStep.CanTransition, nextStep.Name);
        _state.TransitionTo(nextStep);
    }
    
    public void SetState(ManufacturingState state)
    {
        if (_state != null)
        {
            ManufacturingStages.Add(new ManufacturingStage
            {
                Name = _state.Name,
                StartDate = _state.StartDate,
                EndDate = _state.EndDate ?? DateTime.Now
            });
        }
        _state = state;
    }
}