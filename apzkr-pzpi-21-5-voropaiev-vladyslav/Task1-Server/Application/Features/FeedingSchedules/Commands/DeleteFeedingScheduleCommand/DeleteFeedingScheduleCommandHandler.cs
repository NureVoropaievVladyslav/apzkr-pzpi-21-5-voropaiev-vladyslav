namespace Application.Features.FeedingSchedules.Commands.DeleteFeedingScheduleCommand;

public sealed class DeleteFeedingScheduleCommandHandler : IRequestHandler<DeleteFeedingScheduleCommand, Guid>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFeedingScheduleCommandHandler(IFeedingScheduleRepository feedingScheduleRepository, IUnitOfWork unitOfWork)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeleteFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var feedingSchedule = (await _feedingScheduleRepository.GetAsync(request.FeedingScheduleId, cancellationToken))!;
        _feedingScheduleRepository.Delete(feedingSchedule);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return (feedingSchedule.Id);
    }
}