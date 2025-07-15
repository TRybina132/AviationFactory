namespace AviationFactory.Entities.Personnel.Workers;

public class Metalworker : WorkerEmployee
{
    public string Level { get; set; }
    public List<string> Specializations { get; set; }
}