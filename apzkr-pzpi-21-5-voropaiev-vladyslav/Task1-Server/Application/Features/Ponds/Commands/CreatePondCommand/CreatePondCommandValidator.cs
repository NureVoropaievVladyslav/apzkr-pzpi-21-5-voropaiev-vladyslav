namespace Application.Features.Ponds.Commands.CreatePondCommand;

public class CreatePondCommandValidator : AbstractValidator<CreatePondCommand>
{
    public CreatePondCommandValidator()
    {
        RuleFor(x => x.FishSpecies)
            .IsInEnum().WithMessage(Resource.InvalidFishSpecie);

        RuleFor(x => x.FishPopulation)
            .GreaterThan(0).WithMessage(Resource.GreaterThanZero);
    }
}