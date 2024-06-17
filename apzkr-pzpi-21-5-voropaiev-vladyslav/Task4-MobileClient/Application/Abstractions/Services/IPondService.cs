using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IPondService
{
    Task<List<Pond>> GetPondsAsync(CancellationToken cancellationToken);
    Task UpdateScheduleAsync(Pond? currentEntity);
}