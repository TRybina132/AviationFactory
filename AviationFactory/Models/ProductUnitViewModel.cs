using AviationFactory.Models.Enums;

namespace AviationFactory.Models;

public class ProductUnitViewModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string SerialNumber { get; set; }
    public string Model { get; set; }
    public DateTime? ManufactureDate { get; set; }
    public ProductType ProductType { get; set; }
}