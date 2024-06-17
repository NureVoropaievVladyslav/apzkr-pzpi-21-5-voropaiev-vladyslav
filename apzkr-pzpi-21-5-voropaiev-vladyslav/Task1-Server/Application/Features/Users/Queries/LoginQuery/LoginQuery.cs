namespace Application.Features.Users.Queries.LoginQuery;

public record LoginQuery(string Login, string Password) : IRequest<string>;