namespace Application.Features.Users.Queries.LoginQuery;

public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, string>
{
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.LoginAsync(request.Login, request.Password, cancellationToken);
    }
}