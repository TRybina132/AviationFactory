using AviationFactory.Services.Abstractions.Managers;
using AviationFactory.Services.Managers;
using AviationFactory.Services.Repositories;

namespace AviationFactory.Extensions;

public static class ServiceInitializer
{
    public static IProductManager GetProductManager()
    {
        return new ProductManager(ProductRepository.Instance, PersonnelRepository.Instance);
    }
    
    public static IProductUnitManager GetProductUnitManager()
    {
        return new ProductUnitManager(ProductRepository.Instance);
    }
    
    public static IFactoryManager GetFactoryManager()
    {
        return new FactoryManager(FactoryRepository.Instance, PersonnelRepository.Instance);
    }
    
    public static ILabManager GetLabManager()
    {
        return new LabManager(ProductRepository.Instance, PersonnelRepository.Instance, LabRepository.Instance);
    }
}