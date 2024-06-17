namespace Application.Features.Users.Commands.RegisterWorkerCommand;

public sealed class RegisterWorkerCommandHandler : IRequestHandler<RegisterWorkerCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegisterWorkerCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var token = await _userRepository.RegisterUserAsync(user, request.Password, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return token;
    }
}