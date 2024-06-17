using Domain.Enums;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IPasswordManager _passwordManager;
    private readonly IJwtProvider _jwtProvider;

    public UserRepository(IPasswordManager passwordManager, IJwtProvider jwtProvider, ApplicationDbContext context) 
        : base(context)
    {
        _passwordManager = passwordManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken)
    {
        var user = await Context.Users.FirstOrDefaultAsync(x => x.Email == login || x.Username == login, cancellationToken);
        if (user is null)
        {
            throw new DataNotFoundException();
        }

        if (_passwordManager.VerifyPassword(
                password: password,
                hash: user.PasswordHash,
                salt: user.PasswordSalt))
        {
            return _jwtProvider.Generate(user);
        }

        throw new PasswordDoesNotMatchException();
    }
    
    public async Task<string> RegisterUserAsync(User user, string password, CancellationToken cancellationToken)
    {
        if (await Context.Users.AnyAsync(x => x.Email == user.Email || x.Username == user.Username, cancellationToken))
        {
            throw new UserAlreadyExistsException();
        }
        
        var passwordSalt = _passwordManager.GenerateSalt();
        var passwordHash = _passwordManager.HashPassword(password, passwordSalt);
        
        user.PasswordHash = Convert.ToBase64String(passwordHash);
        user.PasswordSalt = Convert.ToBase64String(passwordSalt);

        await CreateAsync(user, cancellationToken);

        return _jwtProvider.Generate(user);
    }

    public void MakeAdmin(User user)
    {
        user.Role = Role.Admin;
        Update(user);
    }

    public async Task CheckEmailAvailabilityAsync(string email, CancellationToken cancellationToken)
    {
        if (await Context.Users.AnyAsync(x => x.Email == email, cancellationToken)) 
        {
            throw new EmailIsUnavailableException();
        }
    }
}