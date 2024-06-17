namespace Domain.Entities;

/// <summary>
/// Represents a base entity with common properties.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }
        
    /// <summary>
    /// Gets or sets the date and time when the entity was created, in UTC.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}