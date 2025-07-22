using AviationFactory.Entities.Products.Planes;

namespace AviationFactory.Extensions;

public static class DisplayExtensions
{
    public static void Display(this FighterPlane fighterPlane)
    {
        if (fighterPlane == null)
        {
            Console.WriteLine("Fighter plane is null.");
            return;
        }

        Console.WriteLine("Fighter Plane Properties:");
        Console.WriteLine($"ID: {fighterPlane.Id}");
        Console.WriteLine($"Producer Name: {fighterPlane.ProducerName}");
        Console.WriteLine($"Model Name: {fighterPlane.ModelName}");
        Console.WriteLine($"Product Type: {fighterPlane.ProductType}");
        Console.WriteLine($"Shop ID: {fighterPlane.ShopId}");
        Console.WriteLine($"Department ID: {fighterPlane.DepartmentId}");
        Console.WriteLine($"Wing Type: {fighterPlane.WingType}");
        Console.WriteLine($"Max Range: {fighterPlane.MaxRange}");
        Console.WriteLine($"Max Speed: {fighterPlane.MaxSpeed}");
        Console.WriteLine($"Max Takeoff Weight: {fighterPlane.MaxTakeoffWeight}");
        Console.WriteLine($"Plane Type: {fighterPlane.PlaneType}");
        Console.WriteLine($"Combat Radius: {fighterPlane.CombatRadius}");
        Console.WriteLine($"Armament Capacity: {fighterPlane.ArmamentCapacity}");
        Console.WriteLine($"Supercruise Capable: {fighterPlane.SupercruiseCapable}");
        if (fighterPlane.PrimaryRole != null)
        {
            Console.WriteLine($"Primary Roles: {string.Join(", ", fighterPlane.PrimaryRole)}");
        }

        if (fighterPlane.Armament != null)
        {
            Console.WriteLine($"Armament: {string.Join(", ", fighterPlane.Armament)}");
        }
    }
}