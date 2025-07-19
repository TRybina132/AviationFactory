namespace AviationFactory.Models.Stages;

public class TestingStage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid LabId { get; set; }
    public List<Guid> TesterIds { get; set; } = new List<Guid>();
    public List<string>? UsedEquipment { get; set; }
}