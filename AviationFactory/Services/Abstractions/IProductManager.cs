using AviationFactory.Models;

namespace AviationFactory.Services.Abstractions;

public interface IProductManager
{
    List<ManufacturingStep> GetManufacturingSteps(Guid productId);
}