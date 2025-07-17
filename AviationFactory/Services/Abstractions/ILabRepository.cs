using AviationFactory.Entities;

namespace AviationFactory.Services.Abstractions;

public interface ILabRepository
{
    List<Lab> GetLabs(List<Guid> labIds);
}