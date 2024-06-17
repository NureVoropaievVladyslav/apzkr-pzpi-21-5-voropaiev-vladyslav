namespace Application.Features.Users.Queries.ExportUsersDataQuery;

public sealed class ExportUsersDataQueryHandler : IRequestHandler<ExportUsersDataQuery, string>
{
    private readonly IUserRepository _userRepository;

    public ExportUsersDataQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(ExportUsersDataQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.ExportToJsonAsync(cancellationToken);
    }
}