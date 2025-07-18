using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Models.Steps;

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
    public List<ManufacturingStage> ManufacturingSteps { get; set; }
    public List<TestingStage> TestingStages { get; set; }
}