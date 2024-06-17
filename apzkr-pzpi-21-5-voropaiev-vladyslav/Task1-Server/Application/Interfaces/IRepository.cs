namespace Application.Interfaces;

/// <summary>
/// Represents a generic repository interface for CRUD operations on entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Asynchronously creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task CreateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);

    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved entity, or null if not found.</returns>
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves all entities.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of entities.</returns>
    Task<List<T>> GetAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a queryable representation of entities for advanced querying.
    /// </summary>
    /// <returns>An IQueryable representing the entities.</returns>
    IQueryable<T> GetQueryable();

    /// <summary>
    /// Exports entities to JSON asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the JSON data.</returns>
    Task<string> ExportToJsonAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Imports entities from JSON asynchronously.
    /// </summary>
    /// <param name="json">JSON string containing the entities.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a collection of imported entities.</returns>
    Task<ICollection<T>> ImportFromJsonAsync(string json, CancellationToken cancellationToken);
}