namespace Application.Features.Users.Commands.MakeAdminCommand;

public sealed class MakeAdminCommandHandler : IRequestHandler<MakeAdminCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MakeAdminCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(MakeAdminCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(request.UserId, cancellationToken))!;
        _userRepository.MakeAdmin(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}