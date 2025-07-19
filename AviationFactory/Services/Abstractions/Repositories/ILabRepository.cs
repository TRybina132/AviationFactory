using AviationFactory.Entities;

namespace AviationFactory.Services.Abstractions.Repositories;

public interface ILabRepository
{
    List<Lab> GetLabs(List<Guid> labIds);
    Lab? GetLab(Guid labId);
}