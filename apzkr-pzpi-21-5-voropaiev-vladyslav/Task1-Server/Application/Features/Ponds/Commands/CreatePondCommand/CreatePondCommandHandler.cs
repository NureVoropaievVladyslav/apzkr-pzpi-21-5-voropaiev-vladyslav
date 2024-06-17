namespace Application.Features.Ponds.Commands.CreatePondCommand;

public sealed class CreatePondCommandHandler : IRequestHandler<CreatePondCommand, Guid>
{
    private readonly IPondRepository _pondRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePondCommandHandler(IPondRepository pondRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _pondRepository = pondRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePondCommand request, CancellationToken cancellationToken)
    {
        var pond = _mapper.Map<Pond>(request);
        await _pondRepository.CreateAsync(pond, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return pond.Id;
    }
}