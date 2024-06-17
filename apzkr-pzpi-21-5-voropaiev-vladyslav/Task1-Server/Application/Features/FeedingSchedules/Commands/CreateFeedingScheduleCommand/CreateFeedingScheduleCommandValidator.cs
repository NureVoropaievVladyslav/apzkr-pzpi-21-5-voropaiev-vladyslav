namespace Application.Features.FeedingSchedules.Commands.CreateFeedingScheduleCommand;

public class CreateFeedingScheduleCommandValidator : AbstractValidator<CreateFeedingScheduleCommand>
{
    public CreateFeedingScheduleCommandValidator()
    {
        RuleFor(x => x.PondId)
            .NotEqual(Guid.Empty).WithMessage(Resource.RequiredField);
    }
}