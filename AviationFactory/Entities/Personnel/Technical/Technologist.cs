namespace AviationFactory.Entities.Personnel.Technical;

public class Technologist : TechnicalEmployee
{
    public List<string>? SkillSet { get; set; }
    public List<string>? Specializations { get; set; }
}

