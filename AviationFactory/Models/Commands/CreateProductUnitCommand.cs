namespace AviationFactory.Models.Commands;

public class CreateProductUnitCommand
{
    public Guid ProductId { get; set; }
    public Guid ShopId { get; set; }
}