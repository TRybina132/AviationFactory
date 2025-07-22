namespace AviationFactory.Extensions;

public class ShopModel
{
    public Guid ShopId { get; set; }
    public List<Guid> Employees { get; set; } = [];
    public List<Guid> Labs { get; set; } = [];
    public List<Guid> Departments { get; set; } = [];
    public List<Guid> Brigades { get; set; } = [];
}