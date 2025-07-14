namespace AviationFactory.Entities;

public class Brigade
{
    public Guid Id { get; set; }
    public Guid ForemanId { get; set; }
    public List<Guid> MembersIds { get; set; }
    public Guid DepartmentId { get; set; }
}