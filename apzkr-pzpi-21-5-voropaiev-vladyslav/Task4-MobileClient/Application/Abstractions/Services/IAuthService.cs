namespace Application.Abstractions.Services;

public interface IAuthService
{
    Task LoginAsync(string email, string password, CancellationToken cancellationToken);
    Task RegisterAsync(string fullname, string email, string password, string username);
}