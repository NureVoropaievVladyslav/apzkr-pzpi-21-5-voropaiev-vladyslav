namespace Application.Features.FeedingSchedules.Commands.UpdateFeedingScheduleCommand;

public sealed class UpdateFeedingScheduleCommandHandler : IRequestHandler<UpdateFeedingScheduleCommand, Guid>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;
    private readonly IPondRepository _pondRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateFeedingScheduleCommandHandler(IFeedingScheduleRepository feedingScheduleRepository, IPondRepository pondRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
        _pondRepository = pondRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdateFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var pond = await _pondRepository.GetAsync(request.PondId, cancellationToken);
        var feedingSchedule = _mapper.Map<FeedingSchedule>(request);
        feedingSchedule.Pond = pond!;
        _feedingScheduleRepository.Update(feedingSchedule);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return feedingSchedule.Id;
    }
}