using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions;

public interface IProductManager
{
    List<ManufacturingStep> GetManufacturingSteps(Guid productId);
    List<BaseProduct> GetProductsAssembledInShop(Guid shopId, ProductType type);
    List<BaseProduct> GetProductsAssembledInDepartment(Guid departmentId, ProductType type);
    List<BaseProduct> GetProducts(ProductType type);
    List<BrigadeViewModel> GetEmployeesForProduct(Guid productId);
    List<Lab> GetLabsInvolvedInTesting(Guid productId);
}