namespace Application.Features.FeedingSchedules.Commands.CreateFeedingScheduleCommand;

public record CreateFeedingScheduleCommand(
    Guid PondId, 
    int FeedingFrequencyInHours = 0, 
    double FoodAmount = 0.0f) : IRequest<Guid>;