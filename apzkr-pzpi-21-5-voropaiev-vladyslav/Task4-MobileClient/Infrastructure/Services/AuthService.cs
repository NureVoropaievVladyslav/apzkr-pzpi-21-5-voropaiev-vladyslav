using Application.Abstractions.Factories;
using Application.Abstractions.Services;
using Application.Features.Auth.Commands;
using Infrastructure.Configurations.Auth;

namespace Infrastructure.Services;

public class AuthService : ServiceBase, IAuthService
{
    private const string ResourceUrl = "users";
    private readonly AuthConfiguration _authConfiguration;
    public AuthService(IHttpClientFactory httpClientFactory, AuthConfiguration authConfiguration) : base(httpClientFactory, authConfiguration)
    {
        _authConfiguration = authConfiguration;
    }

    public async Task LoginAsync(string email, string password, CancellationToken cancellationToken)
    {
        var token = await SendRequestAsync<LoginCommand, string>(HttpMethod.Post, $"{ResourceUrl}/login", new LoginCommand(email, password), cancellationToken);
        _authConfiguration.AccessToken = token;
    }

    public Task RegisterAsync(string fullname, string email, string password, string username)
    {
        throw new NotImplementedException();
    }
}