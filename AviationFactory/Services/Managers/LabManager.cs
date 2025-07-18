using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Managers;

public class LabManager : ILabManager
{
    private readonly IProductRepository _productRepository;
    private readonly IPersonnelRepository _personnelRepository;
    private readonly ILabRepository _labRepository;


    public LabManager(
        IProductRepository productRepository, 
        IPersonnelRepository personnelRepository, 
        ILabRepository labRepository)
    {
        _productRepository = productRepository;
        _personnelRepository = personnelRepository;
        _labRepository = labRepository;
    }

    public List<BaseEmployee> GetTestersForProduct(Guid productId)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null)
        {
            return [];
        }
        
        var labs = _labRepository.GetLabs(product.LabsIds);
        var testers = new List<BaseEmployee>();
        
        foreach (var lab in labs)
        {
            var labTesters = _personnelRepository.GetEmployees(lab.WorkersIds ?? []);
            testers.AddRange(labTesters);
        }
        
        return testers;
    }

    public List<BaseEmployee> GetTestersForProducts(ProductType type)
    {
        var products = _productRepository.GetProducts(p => p.ProductType == type);
        var testers = new List<BaseEmployee>();

        foreach (var product in products)
        {
            var productTesters = GetTestersForProduct(product.Id);
            testers.AddRange(productTesters);
        }

        return testers;
    }

    public List<BaseEmployee> GetTestersForLab(Guid labId)
    {
        var lab = _labRepository.GetLab(labId);
        if (lab == null)
        {
            return [];
        }

        var testers = _personnelRepository.GetEmployees(lab.WorkersIds ?? []);
        return testers;
    }
    
    public List<Lab> GetLabsInvolvedInTesting(Guid productId)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null)
        {
            return [];
        }
        
        return _labRepository.GetLabs(product.LabsIds);
    }   
}