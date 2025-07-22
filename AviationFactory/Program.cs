using System.Text.Json;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Extensions;
using AviationFactory.Models.Commands;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Repositories;

var militaryFacility = DataInitialization.InitializePersonnelAndFacility("Mil");
var civilFacility = DataInitialization.InitializePersonnelAndFacility("Civil");
var cargoFacility = DataInitialization.InitializePersonnelAndFacility("Cargo");


var civilPlanes = ProductDataInitializer
    .InitializePassengerPlanes([civilFacility.ShopId], civilFacility.Departments, civilFacility.Labs);
var militaryPlanes = ProductDataInitializer
    .InitializeMilitaryPlanes([militaryFacility.ShopId], militaryFacility.Departments, militaryFacility.Labs);
var militaryHelicopters = ProductDataInitializer
    .InitializeHelicopters([militaryFacility.ShopId], militaryFacility.Departments, militaryFacility.Labs);
var cargoPlanes = ProductDataInitializer
    .InitializeCargoPlanes([cargoFacility.ShopId], cargoFacility.Departments, cargoFacility.Labs);
var missiles =
    ProductDataInitializer.InitializeMissiles([militaryFacility.ShopId], militaryFacility.Departments,
        militaryFacility.Labs);

var productManager = ServiceInitializer.GetProductManager();
var planes = productManager.GetProducts(ProductType.Plane);
var helicopters = productManager.GetProducts(ProductType.Helicopter);

Console.WriteLine($"Total planes: {planes.Count}");
Console.WriteLine($"Total helicopters: {helicopters.Count}");

Console.WriteLine("===================");

var militaryProduct = productManager
    .GetProductsAssembledInShop(militaryFacility.ShopId, ProductType.Plane)
    .FirstOrDefault(p => p is FighterPlane);

if (militaryProduct != null)
{
    var fighterPlane = militaryProduct as FighterPlane;
    Console.WriteLine($"Fighter plane: ");
    fighterPlane.Display();
    var createProductUnitCommand = new CreateProductUnitCommand
    {
        ProductId = militaryProduct.Id,
        ShopId = militaryFacility.ShopId,
    };
    Console.WriteLine("===================");
    var productUnitManager = ServiceInitializer.GetProductUnitManager();
    var productUnitId = productUnitManager.CreateProductUnit(createProductUnitCommand);
    if (productUnitId != null)
    {
        Console.WriteLine("Product unit created successfully.");
        var steps = productManager.GetManufacturingSteps(militaryProduct.Id);
        var assemble = steps.FirstOrDefault(s => s.Name == "AssembleBase");
        var test = steps.FirstOrDefault(s => s.Name == "Test");
        var assembleWeapons = steps.FirstOrDefault(s => s.Name == "AssembleWeapons");

        productUnitManager.MoveProductUnitToNextStage(productUnitId.Value, assemble.Id);
        var productStage1 = productUnitManager.GetProductUnitById(productUnitId.Value);
        Console.WriteLine($"Product unit moved to AssembleBase stage. {productStage1.CurrentState.Name}");
        
        productUnitManager.MoveProductUnitToNextStage(productUnitId.Value, test.Id);
        
        var productStage2 = productUnitManager.GetProductUnitById(productUnitId.Value);
        Console.WriteLine($"Product unit wasnt moved to test. {productStage2.CurrentState.Name}");
        
        
        productUnitManager.MoveProductUnitToNextStage(productUnitId.Value, assembleWeapons.Id);
        
        var productStage3 = productUnitManager.GetProductUnitById(productUnitId.Value);
        Console.WriteLine($"Product moved to next stage. {productStage3.CurrentState.Name}");
    }
}
