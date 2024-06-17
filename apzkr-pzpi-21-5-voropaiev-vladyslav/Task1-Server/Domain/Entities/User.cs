using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = null!;
    
    public string Email  { get; set; } = null!;

    public string Username { get; set; } = null!;
    
    public string PasswordHash  { get; set; } = null!;
    
    public string PasswordSalt  { get; set; } = null!;

    public Role Role { get; set; } = Role.Worker;

    public Guid? PondId { get; set; }
    
    public Pond? WorkArea { get; set; }
}