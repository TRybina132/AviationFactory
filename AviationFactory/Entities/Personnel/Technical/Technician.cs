namespace AviationFactory.Entities.Personnel.Technical;

public class Technician : TechnicalEmployee
{
    public string Specialization { get; set; }
    public List<string> Tools { get; set; }
}