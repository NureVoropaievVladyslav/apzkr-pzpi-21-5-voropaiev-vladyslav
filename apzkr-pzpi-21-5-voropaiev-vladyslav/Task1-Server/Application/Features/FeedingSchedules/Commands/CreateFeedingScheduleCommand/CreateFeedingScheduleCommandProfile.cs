namespace Application.Features.FeedingSchedules.Commands.CreateFeedingScheduleCommand;

public class CreateFeedingScheduleCommandProfile : Profile
{
    public CreateFeedingScheduleCommandProfile()
    {
        CreateMap<CreateFeedingScheduleCommand, FeedingSchedule>();
    }
}