namespace Application.Features.FeedingSchedules.Commands.DeleteFeedingScheduleCommand;

public class DeleteFeedingScheduleCommandValidator : AbstractValidator<DeleteFeedingScheduleCommand>
{
    public DeleteFeedingScheduleCommandValidator()
    {
        RuleFor(x => x.FeedingScheduleId)
            .NotEqual(Guid.Empty).WithMessage(Resource.RequiredField);
    }
}