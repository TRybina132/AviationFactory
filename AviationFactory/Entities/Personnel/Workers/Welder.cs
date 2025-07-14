namespace AviationFactory.Entities.Personnel.Workers;

public class Welder : BaseEmployee
{
    public List<string> Specializations { get; set; }
    public List<string> Materials { get; set; }
}