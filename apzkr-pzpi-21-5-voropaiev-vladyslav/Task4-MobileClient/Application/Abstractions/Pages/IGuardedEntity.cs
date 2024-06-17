using Domain.Guards;

namespace Application.Abstractions.Pages;

public interface IGuardedEntity
{
    IEnumerable<Guard> Guards { get; }
}