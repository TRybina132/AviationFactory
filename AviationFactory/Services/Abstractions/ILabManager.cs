using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions;

public interface ILabManager
{
    List<BaseEmployee> GetTestersForProduct(Guid productId);
    List<BaseEmployee> GetTestersForProducts(ProductType type);
    List<BaseEmployee> GetTestersForLab(Guid labId);
    List<Lab> GetLabsInvolvedInTesting(Guid productId);
}