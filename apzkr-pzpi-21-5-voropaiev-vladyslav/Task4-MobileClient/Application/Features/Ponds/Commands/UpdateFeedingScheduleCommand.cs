namespace Application.Features.Ponds.Commands;

public record UpdateFeedingScheduleCommand(
    Guid Id,
    Guid PondId, 
    int FeedingFrequencyInHours, 
    double FoodAmount);