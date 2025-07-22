using AviationFactory.Entities;
using AviationFactory.Entities.Personnel.Technical;
using AviationFactory.Entities.Personnel.Workers;
using AviationFactory.Models.Enums;
using AviationFactory.Services.Repositories;

namespace AviationFactory.Extensions;

public static class DataInitialization
{
    public static ShopModel InitializePersonnelAndFacility(string prefix)
    {
        var model = new ShopModel();
        var personnelRepository = PersonnelRepository.Instance;
        var factoryRepository = FactoryRepository.Instance;
        var labRepository = LabRepository.Instance;
        
        var departmentId = Guid.NewGuid();
        var brigadeId = Guid.NewGuid();
        var shopId = Guid.NewGuid();
        
        var foreman = new Engineer
        {
            Id = Guid.NewGuid(),
            FirstName = "Tom",
            LastName = $"{prefix}Hwak",
            Address = "Los Angeles",
            AlmaMater = "University",
            BirthDate = new DateTime(1988, 6,2),
            Degree = "Professor",
            Email = "tom2@gmail.com",
            DepartmentId = departmentId,
            ShopId = shopId,
            Specialization = "Electronics",
            TeamId = brigadeId,
            Gender = Gender.Male,
        };
        var technician = new Technician()
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = $"{prefix}Green",
            Address = "Los Angeles",
            AlmaMater = "University",
            BirthDate = new DateTime(1999, 6,2),
            Degree = "Master",
            Email = "jane2@gmail.com",
            DepartmentId = departmentId,
            ShopId = shopId,
            Specialization = "Electronics",
            Tools = ["Adobe AutoCad"],
            TeamId = brigadeId,
            Gender = Gender.Female,
        };
        var welder = new Welder()
        {
            Id = Guid.NewGuid(),
            FirstName = "Bob",
            LastName = $"{prefix}Orwel",
            Address = "Los Angeles",
            BirthDate = new DateTime(1999, 6,2),
            Email = "bobOr44@gmail.com",
            DepartmentId = departmentId,
            ShopId = shopId,
            Materials = ["metal"],
            TeamId = brigadeId,
            Gender = Gender.Female,
        };
        var labTechnician = new Technician()
        {
            Id = Guid.NewGuid(),
            FirstName = "Eren",
            LastName = $"{prefix}Keys",
            Address = "Los Angeles",
            AlmaMater = "University",
            BirthDate = new DateTime(1999, 6,2),
            Degree = "Master",
            Email = "erenk2@gmail.com",
            DepartmentId = departmentId,
            ShopId = shopId,
            Specialization = "Testing",
            Tools = ["testing stand"],
            TeamId = brigadeId,
            Gender = Gender.Female,
        };
        personnelRepository.CreateEmployee(labTechnician);
        personnelRepository.CreateEmployee(foreman);
        personnelRepository.CreateEmployee(technician);
        personnelRepository.CreateEmployee(welder);
        model.Employees.AddRange([foreman.Id, technician.Id, welder.Id, labTechnician.Id]);
        
        
        var brigadeMilPlanes = new Brigade
        {
            Id = Guid.NewGuid(),
            DepartmentId = departmentId,
            ForemanId = foreman.Id,
            MembersIds = [foreman.Id, welder.Id, technician.Id]
        };
        var brigadeTestPlanes = new Brigade
        {
            Id = Guid.NewGuid(),
            DepartmentId = departmentId,
            ForemanId = labTechnician.Id,
            MembersIds = [labTechnician.Id]
        };
        personnelRepository.CreateBrigade(brigadeMilPlanes);
        personnelRepository.CreateBrigade(brigadeTestPlanes);
        model.Brigades.AddRange([brigadeMilPlanes.Id, brigadeTestPlanes.Id]);
        
        
        // Create departments
        var department1 = new Department
        {
            Id = Guid.NewGuid(),
            Name = $"{prefix}Engineering",
            ShopId = shopId,
            BrigadesIds = [brigadeMilPlanes.Id]
        };
        var department2 = new Department
        {
            Id = Guid.NewGuid(),
            ShopId = shopId,
            Name = $"{prefix}Quality Control",
            BrigadesIds = [brigadeTestPlanes.Id]
        };
        factoryRepository.CreateDepartment(department1);
        factoryRepository.CreateDepartment(department2);
        model.Departments.AddRange([department1.Id, department2.Id]);
        
        var lab = new Lab
        {
            Id = Guid.NewGuid(),
            Name = $"{prefix}Testing facility 12",
            Departments = [department1.Id, department2.Id],
            Description = "Test products",
            WorkersIds = [labTechnician.Id]
        };
        labRepository.CreateLab(lab);
        model.Labs.AddRange([lab.Id]);

        return model;
    }
}

public class ShopModel
{
    public List<Guid> Employees { get; set; } = [];
    public List<Guid> Labs { get; set; } = [];
    public List<Guid> Departments { get; set; } = [];
    public List<Guid> Brigades { get; set; } = [];
}

