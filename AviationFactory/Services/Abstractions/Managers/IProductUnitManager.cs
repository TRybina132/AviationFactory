using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Commands;
using AviationFactory.Models.Enums;
using AviationFactory.Models.Stages;

namespace AviationFactory.Services.Abstractions.Managers;

public interface IProductUnitManager
{
    List<ProductUnitViewModel> GetProductsTestedInLab(
        Guid labId, 
        DateTime startTime,
        DateTime endTime,
        ProductType? productType = null);
    
    bool CreateProductUnit(CreateProductUnitCommand command);
    bool AddTestingStageToProductUnit(
        Guid productUnitId, 
        TestingStage testingStage);
    
    bool MoveProductUnitToNextStage(
        Guid productUnitId,
        Guid nextStepId);
}