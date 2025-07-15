using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Products;

public abstract class BaseProduct
{
    public Guid Id { get; set; }
    public string ProducerName { get; set; }
    public string ModelName { get; set; }
    public ProductType ProductType { get; set; }
    public Guid ShopId { get; set; }
    public Guid DepartmentId { get; set; }
}