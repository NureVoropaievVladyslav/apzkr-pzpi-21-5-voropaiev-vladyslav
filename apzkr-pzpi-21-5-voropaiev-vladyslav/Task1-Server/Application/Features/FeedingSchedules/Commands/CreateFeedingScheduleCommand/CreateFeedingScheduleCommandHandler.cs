namespace Application.Features.FeedingSchedules.Commands.CreateFeedingScheduleCommand;

public sealed class CreateFeedingScheduleCommandHandler : IRequestHandler<CreateFeedingScheduleCommand, Guid>
{
    private readonly IPondRepository _pondRepository;
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeedingScheduleCommandHandler(IPondRepository pondRepository, IFeedingScheduleRepository feedingScheduleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _pondRepository = pondRepository;
        _feedingScheduleRepository = feedingScheduleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var pond = (await _pondRepository.GetAsync(request.PondId, cancellationToken))!;
        var feedingSchedule = _mapper.Map<FeedingSchedule>(request);
        feedingSchedule.Pond = pond;
        await _feedingScheduleRepository.CreateAsync(feedingSchedule, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return feedingSchedule.Id;
    }
}