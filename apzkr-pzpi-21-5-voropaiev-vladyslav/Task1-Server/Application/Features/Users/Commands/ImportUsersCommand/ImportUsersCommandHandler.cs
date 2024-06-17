namespace Application.Features.Users.Commands.ImportUsersCommand;

public class ImportUsersCommandHandler : IRequestHandler<ImportUsersCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ImportUsersCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ImportUsersCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.ImportFromJsonAsync(request.JsonContent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}