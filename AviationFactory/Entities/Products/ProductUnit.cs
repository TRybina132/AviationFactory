namespace AviationFactory.Entities.Products;

// Represents assembled product
public class ProductUnit
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string SerialNumber { get; set; }
    public DateTime ManufactureDate { get; set; }
    public Guid ShopId { get; set; }
}