using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Entities.Products;
using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Abstractions;
using AviationFactory.Services.Abstractions.Managers;
using AviationFactory.Services.Abstractions.Repositories;

namespace AviationFactory.Services.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;
    private readonly IPersonnelRepository _personnelRepository;

    public ProductManager(
        IProductRepository productRepository, 
        IPersonnelRepository personnelRepository)
    {
        _productRepository = productRepository;
        _personnelRepository = personnelRepository;
    }

    public bool CreateProduct(BaseProduct product)
    {
        return _productRepository.CreateProduct(product);
    }

    public List<ManufacturingStep> GetManufacturingSteps(Guid productId)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null)
        {
            return [];
        }
        
        return _productRepository.GetManufacturingSteps(product.ManufacturingStepsIds);
    }

    public List<BaseProduct> GetProductsAssembledInShop(Guid shopId, ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.ShopId == shopId && p.ProductType == type);
        
        return products;
    }

    public List<BaseProduct> GetProductsAssembledInDepartment(Guid departmentId, ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.DepartmentId == departmentId && p.ProductType == type);
        
        return products;
    }

    public List<BaseProduct> GetProducts(ProductType type)
    {
        var products = _productRepository
            .GetProducts(p => p.ProductType == type);
        
        return products;
    }

    public List<BrigadeViewModel> GetEmployeesForProduct(Guid productId)
    {
        var product = _productRepository.GetProduct(productId);
        
        if (product == null)
        {
            return [];
        }
        
        var viewModels = new List<BrigadeViewModel>();
        var brigades = _personnelRepository
            .GetBrigadesForDepartment(product.DepartmentId);
        foreach (var brigade in brigades)
        {
            var foreman = _personnelRepository.GetEmployee(brigade.ForemanId);
            var employees = _personnelRepository.GetEmployees(brigade.MembersIds);
            viewModels.Add(new BrigadeViewModel
            {
                Id = brigade.Id,
                DepartmentId = brigade.DepartmentId,
                Foreman = foreman,
                Members = employees
            });
        }
        
        return viewModels;
    }
}