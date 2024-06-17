using Domain.Enums;

namespace Application.Features.Users.Queries.GetAllUsersQuery;

public class UserResponse
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string FullName { get; set; } = null!;
    
    public string Email  { get; set; } = null!;

    public string Username { get; set; } = null!;

    public Role Role { get; set; }
    
    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}