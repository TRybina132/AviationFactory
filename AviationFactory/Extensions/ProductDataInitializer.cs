using System;
using System.Collections.Generic;
using AviationFactory.Entities.Products;
using AviationFactory.Entities.Products.Helicopter;
using AviationFactory.Entities.Products.Missiles;
using AviationFactory.Entities.Products.Planes;
using AviationFactory.Models;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Repositories;

namespace AviationFactory.Extensions;

public static class ProductDataInitializer
{
    private static readonly Random _random = new Random();
    
    public static List<BaseProduct> InitializeProducts(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var products = new List<BaseProduct>();
        
        // Add planes
        products.AddRange(InitializePassengerPlanes(shopIds, departmentIds, labIds));
        products.AddRange(InitializeCargoPlanes(shopIds, departmentIds, labIds));
        products.AddRange(InitializeMilitaryPlanes(shopIds, departmentIds, labIds));
        
        // Add helicopters
        products.AddRange(InitializeHelicopters(shopIds, departmentIds, labIds));
        
        // Add missiles
        products.AddRange(InitializeMissiles(shopIds, departmentIds, labIds));
        
        return products;
    }
    
    public static List<BaseProduct> InitializePassengerPlanes(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var productRepository = ProductRepository.Instance;

        var stepsIds = new List<Guid>();
        var test = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Conduct final tests of the assembled plane.",
            IsFinal = true,
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = new List<Guid>()
        };
        productRepository.CreateManufacturingStep(test);
        var assembleSalon = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleSalon",
            Description = "Assemble the passenger salon.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [test.Id],
        };
        productRepository.CreateManufacturingStep(assembleSalon);
        var assemble = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleBase",
            Description = "Assemble the main structure of the plane.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [assembleSalon.Id],
        };
        productRepository.CreateManufacturingStep(assemble);
        stepsIds.AddRange([test.Id, assembleSalon.Id, assemble.Id]);
        
        
        var passengerPlanes = new List<BaseProduct>
        {
            new PassengerPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Boeing",
                ModelName = "737-800",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("CFM56", "CFM International", 2),
                WingType = "Low-wing, swept",
                MaxRange = 5765,
                MaxSpeed = 946,
                MaxTakeoffWeight = 79015,
                PlaneType = PlaneType.Passenger,
                PassengerCapacity = 189,
            },
            new PassengerPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Airbus",
                ModelName = "A320neo",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("LEAP-1A", "CFM International", 2),
                WingType = "Low-wing, swept",
                MaxRange = 6300,
                MaxSpeed = 903,
                MaxTakeoffWeight = 79000,
                PlaneType = PlaneType.Passenger,
                PassengerCapacity = 195
            }
        };
        productRepository.CreateProducts(passengerPlanes);
        
        return passengerPlanes;
    }
    
    public static List<BaseProduct> InitializeCargoPlanes(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var productRepository = ProductRepository.Instance;

        var stepsIds = new List<Guid>();
        var test = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Conduct final tests of the assembled plane.",
            IsFinal = true,
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = new List<Guid>()
        };
        productRepository.CreateManufacturingStep(test);
        var assemble = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleBase",
            Description = "Assemble the main structure of the plane.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [test.Id],
        };
        productRepository.CreateManufacturingStep(assemble);
        stepsIds.AddRange([test.Id, assemble.Id]);
        var cargoPlanes = new List<BaseProduct>
        {
            new CargoPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Boeing",
                ModelName = "747-8F",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("GEnx-2B67", "General Electric", 4),
                WingType = "Low-wing, swept",
                MaxRange = 8130,
                MaxSpeed = 908,
                MaxTakeoffWeight = 447700,
                PlaneType = PlaneType.Cargo,
                LoadCapacity = 137.7,
                Height = 20,
                DoorFormFactor = "Front cargo door"
            },
            new CargoPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Airbus",
                ModelName = "A330-200F",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("Trent 772B", "Rolls-Royce", 2),
                WingType = "Low-wing, swept",
                MaxRange = 7400,
                MaxSpeed = 871,
                MaxTakeoffWeight = 233000,
                PlaneType = PlaneType.Cargo,
                LoadCapacity = 70,
                Height = 14
            }
        };
        
        productRepository.CreateProducts(cargoPlanes);
        
        return cargoPlanes;
    }
    
    public static List<BaseProduct> InitializeMilitaryPlanes(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var productRepository = ProductRepository.Instance;

        var stepsIds = new List<Guid>();
        var test = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Conduct final tests of the assembled plane.",
            IsFinal = true,
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = new List<Guid>()
        };
        productRepository.CreateManufacturingStep(test);
        var assembleWeapons = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleWeapons",
            Description = "Assemble the weapons.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [test.Id],
        };
        productRepository.CreateManufacturingStep(assembleWeapons);
        var assemble = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleBase",
            Description = "Assemble the main structure of the plane.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [assembleWeapons.Id],
        };
        productRepository.CreateManufacturingStep(assemble);
        stepsIds.AddRange([test.Id, assembleWeapons.Id, assemble.Id]);
        
        var militaryPlanes = new List<BaseProduct>
        {
            new FighterPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Lockheed Martin",
                ModelName = "F-35 Lightning II",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("F135", "Pratt & Whitney", 1),
                WingType = "Delta wing, stealth",
                MaxRange = 2200,
                MaxSpeed = 1930,
                MaxTakeoffWeight = 31800,
                PlaneType = PlaneType.Military,
                ArmamentCapacity = 8160,
                SupercruiseCapable = true
            },
            new FighterPlane
            {
                Id = Guid.NewGuid(),
                ProducerName = "Boeing",
                ModelName = "F/A-18E Super Hornet",
                ProductType = ProductType.Plane,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 3),
                Engines = GenerateEngines("F414-GE-400", "General Electric", 2),
                WingType = "Mid-wing, swept",
                MaxRange = 2346,
                MaxSpeed = 1915,
                MaxTakeoffWeight = 29937,
                PlaneType = PlaneType.Military,
                ArmamentCapacity = 8050,
                SupercruiseCapable = false
            }
        };
        productRepository.CreateProducts(militaryPlanes);
        
        return militaryPlanes;
    }
    
    public static List<BaseProduct> InitializeHelicopters(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var productRepository = ProductRepository.Instance;

        var stepsIds = new List<Guid>();
        var test = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Conduct final tests of the assembled helicopter.",
            IsFinal = true,
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = new List<Guid>()
        };
        productRepository.CreateManufacturingStep(test);
        
        var assembleWeapons = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleWeapons",
            Description = "Assemble the weapons.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [test.Id],
        };
        productRepository.CreateManufacturingStep(assembleWeapons);
        
        var assembleRotor = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleRotor",
            Description = "Assemble the rotor.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [test.Id, assembleWeapons.Id],
        };
        productRepository.CreateManufacturingStep(assembleRotor);
        var assemble = new ManufacturingStep
        {
            Id = Guid.NewGuid(),
            Name = "AssembleBase",
            Description = "Assemble the main structure of the plane.",
            DepartmentId = GetRandomElement(departmentIds),
            CanTransition = [assembleRotor.Id],
        };
        productRepository.CreateManufacturingStep(assemble);
        stepsIds.AddRange([test.Id, assembleRotor.Id, assemble.Id]);

        var attackHelicopterSteps = new List<Guid>(stepsIds);
        attackHelicopterSteps.Add(assembleWeapons.Id);
        
        var helicopters = new List<BaseProduct>
        {
            new AttackHelicopter()
            {
                Id = Guid.NewGuid(),
                ProducerName = "Sikorsky",
                ModelName = "UH-60 Black Hawk",
                ProductType = ProductType.Helicopter,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = attackHelicopterSteps,
                LabsIds = GetRandomSubset(labIds, 2),
                RotorType = "Four-blade main rotor",
                MaxAltitude = 5790,
                MaxSpeed = 357,
                MaxTakeoffWeight = 9979,
                Range = 580,
                EngineType = "Twin turboshaft T700-GE-701D",
                Type = HelicopterType.Attack,
                WeaponSystems = ["Hellfire missiles", "rockets"],
                ArmorLevel = "Ballistic protection",
                Avionics = ["AN/APR-39 radar warning receiver"]
            },
            new PassengerHelicopter()
            {
                Id = Guid.NewGuid(),
                ProducerName = "Bell",
                ModelName = "407",
                ProductType = ProductType.Helicopter,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = stepsIds,
                LabsIds = GetRandomSubset(labIds, 2),
                RotorType = "Four-blade main rotor",
                MaxAltitude = 5698,
                MaxSpeed = 259,
                MaxTakeoffWeight = 2268,
                Range = 612,
                EngineType = "Rolls-Royce 250-C47B/8 turboshaft",
                Type = HelicopterType.Passenger,
                PassengerCapacity = 6,
            }
        };
        
        productRepository.CreateProducts(helicopters);
        
        return helicopters;
    }
    
    public static List<BaseProduct> InitializeMissiles(List<Guid> shopIds, List<Guid> departmentIds, List<Guid> labIds)
    {
        var productRepository = ProductRepository.Instance;
        
        var missiles = new List<BaseProduct>
        {
            new AamMissile()
            {
                Id = Guid.NewGuid(),
                ProducerName = "Raytheon",
                ModelName = "Tomahawk",
                ProductType = ProductType.Missile,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = GenerateRandomGuids(3),
                LabsIds = GetRandomSubset(labIds, 2),
                Range = 2500,
                Payload = 450,
                GuidanceSystem = "GPS/INS, TERCOM, DSMAC",
                Speed = 30,
                Maneuverability = 200,
                TargetingMode = "Active radar homing"
            },
            new BallisticMissile
            {
                Id = Guid.NewGuid(),
                ProducerName = "Lockheed Martin",
                ModelName = "ATACMS",
                ProductType = ProductType.Missile,
                ShopId = GetRandomElement(shopIds),
                DepartmentId = GetRandomElement(departmentIds),
                ManufacturingStepsIds = GenerateRandomGuids(3),
                LabsIds = GetRandomSubset(labIds, 2),
                Range = 300,
                Payload = 230,
                GuidanceSystem = "GPS/INS",
                MaximumAltitude = 50000,
                Speed = 1000,
                WarheadType = "Nuclear"
            }
        };
        
        
        productRepository.CreateProducts(missiles);
        
        return missiles;
    }
    
    private static List<EngineModel> GenerateEngines(string name, string manufacturer, int count)
    {
        var engines = new List<EngineModel>();
        
        for (int i = 0; i < count; i++)
        {
            engines.Add(new EngineModel
            {
                Model = name,
                Manufacturer = manufacturer,
                Power = _random.Next(10000, 40000),
                Type = (EngineType)_random.Next(0, Enum.GetValues(typeof(EngineType)).Length)
            });
        }
        
        return engines;
    }
    
    private static List<Guid> GenerateRandomGuids(int count)
    {
        var guids = new List<Guid>();
        
        for (int i = 0; i < count; i++)
        {
            guids.Add(Guid.NewGuid());
        }
        
        return guids;
    }
    
    private static Guid GetRandomElement(List<Guid> list)
    {
        if (list == null || list.Count == 0)
            return Guid.NewGuid();
            
        return list[_random.Next(list.Count)];
    }
    
    private static List<Guid> GetRandomSubset(List<Guid> list, int maxCount)
    {
        if (list == null || list.Count == 0)
            return GenerateRandomGuids(maxCount);
        
        var count = _random.Next(1, Math.Min(maxCount, list.Count) + 1);
        var shuffled = list.OrderBy(x => _random.Next()).ToList();
        return shuffled.Take(count).ToList();
    }
}
