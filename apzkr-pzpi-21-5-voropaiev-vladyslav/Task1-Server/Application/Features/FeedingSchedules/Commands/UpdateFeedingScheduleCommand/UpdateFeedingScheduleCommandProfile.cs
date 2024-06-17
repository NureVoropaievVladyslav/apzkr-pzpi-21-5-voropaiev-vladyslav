namespace Application.Features.FeedingSchedules.Commands.UpdateFeedingScheduleCommand;

public class UpdateFeedingScheduleCommandProfile : Profile
{
    public UpdateFeedingScheduleCommandProfile()
    {
        CreateMap<UpdateFeedingScheduleCommand, FeedingSchedule>();
    }
}