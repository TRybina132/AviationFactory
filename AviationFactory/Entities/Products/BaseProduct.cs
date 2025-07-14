namespace AviationFactory.Entities.Products;

public abstract class BaseProduct
{
    public Guid Id { get; set; }
    public string ProducerName { get; set; }
    public string ModelName { get; set; }
}