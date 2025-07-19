using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;

namespace AviationFactory.Services.Abstractions.Managers;

public interface IProductManager
{
    bool CreateProduct(BaseProduct product);
    List<ManufacturingStep> GetManufacturingSteps(Guid productId);
    List<BaseProduct> GetProductsAssembledInShop(Guid shopId, ProductType type);
    List<BaseProduct> GetProductsAssembledInDepartment(Guid departmentId, ProductType type);
    List<BaseProduct> GetProducts(ProductType type);
    List<BrigadeViewModel> GetEmployeesForProduct(Guid productId);
}