namespace Application.Interfaces;

/// <summary>
/// Represents a unit of work interface for managing transactions and changes in the database context.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves changes to the underlying database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}