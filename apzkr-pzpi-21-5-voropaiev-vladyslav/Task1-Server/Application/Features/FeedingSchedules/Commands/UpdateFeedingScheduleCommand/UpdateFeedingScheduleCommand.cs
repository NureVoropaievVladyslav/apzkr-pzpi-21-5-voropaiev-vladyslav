namespace Application.Features.FeedingSchedules.Commands.UpdateFeedingScheduleCommand;

public record UpdateFeedingScheduleCommand(
    Guid Id,
    Guid PondId, 
    int FeedingFrequencyInHours, 
    double FoodAmount) : IRequest<Guid>;