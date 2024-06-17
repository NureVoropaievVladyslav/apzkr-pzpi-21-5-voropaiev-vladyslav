namespace Application.Features.Users.Queries.GetAllUsersQuery;

public record GetAllUsersQuery : IRequest<List<UserResponse>>;