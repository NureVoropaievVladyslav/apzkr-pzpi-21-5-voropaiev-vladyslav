namespace Application.Features.FeedingSchedules.Commands.UpdateFeedingScheduleCommand;

public class UpdateFeedingScheduleCommandValidator : AbstractValidator<UpdateFeedingScheduleCommand>
{
    public UpdateFeedingScheduleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(Resource.RequiredField);

        RuleFor(x => x.PondId)
            .NotEqual(Guid.Empty).WithMessage(Resource.RequiredField);

        RuleFor(x => x.FoodAmount)
            .GreaterThan(0).WithMessage(Resource.GreaterThanZero);
        
        RuleFor(x => x.FeedingFrequencyInHours)
            .GreaterThan(0).WithMessage(Resource.GreaterThanZero);
    }
}