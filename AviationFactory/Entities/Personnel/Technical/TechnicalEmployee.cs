using AviationFactory.Models.Enums;

namespace AviationFactory.Entities.Personnel.Technical;

// Base abstract class for technical employees
public abstract class TechnicalEmployee : BaseEmployee
{
    public int YearsOfExperience { get; set; }
    public string AlmaMater { get; set; }
    public string Degree { get; set; }
    public TechnicalSpecialization TechSpecialization { get; set; }
}