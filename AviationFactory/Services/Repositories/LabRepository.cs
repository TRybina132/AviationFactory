using AviationFactory.Entities;
using AviationFactory.Services.Abstractions;

namespace AviationFactory.Services.Repositories;

public class LabRepository : ILabRepository
{
    private readonly List<Lab> _labs;
    private static readonly LabRepository _instance;
    
    private LabRepository()
    {
        _labs = new List<Lab>();
    }
    
    static LabRepository()
    {
        _instance = new LabRepository();
    }
    
    public static LabRepository Instance => _instance;
    public List<Lab> GetLabs(List<Guid> labIds)
    {
        return _labs.Where(l => labIds.Contains(l.Id)).ToList();
    }
}