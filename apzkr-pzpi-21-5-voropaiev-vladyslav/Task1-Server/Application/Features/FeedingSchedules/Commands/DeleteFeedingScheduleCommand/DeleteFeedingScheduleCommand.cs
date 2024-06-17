namespace Application.Features.FeedingSchedules.Commands.DeleteFeedingScheduleCommand;

public record DeleteFeedingScheduleCommand(Guid FeedingScheduleId) : IRequest<Guid>;