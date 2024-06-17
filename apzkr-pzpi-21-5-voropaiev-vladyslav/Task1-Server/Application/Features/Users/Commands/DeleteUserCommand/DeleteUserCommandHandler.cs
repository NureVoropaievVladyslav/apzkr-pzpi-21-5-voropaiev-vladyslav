namespace Application.Features.Users.Commands.DeleteUserCommand;

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(request.UserId, cancellationToken))!;
        _userRepository.Delete(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}