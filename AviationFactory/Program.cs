using System.Text.Json;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Extensions;
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

var militaryProduct = productManager
    .GetProductsAssembledInShop(militaryFacility.ShopId, ProductType.Plane)
    .FirstOrDefault(p => p is FighterPlane);

if (militaryProduct != null)
{
    Console.WriteLine($"Fighter plane: {JsonSerializer.Serialize(militaryProduct)}");
}
