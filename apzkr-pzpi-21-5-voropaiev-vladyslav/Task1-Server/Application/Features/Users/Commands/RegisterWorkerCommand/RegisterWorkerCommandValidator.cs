namespace Application.Features.Users.Commands.RegisterWorkerCommand;

public class RegisterWorkerCommandValidator : AbstractValidator<RegisterWorkerCommand>
{
    public RegisterWorkerCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(Resource.RequiredField)
            .MinimumLength(8).WithMessage(Resource.FullNameMustBeEightCharacters);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(Resource.RequiredField)
            .EmailAddress().WithMessage(Resource.EmailNotValid);
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Resource.RequiredField)
            .MinimumLength(5).WithMessage(Resource.UsernameMustBeFiveCharacters)
            .Matches("[a-z]+$").WithMessage(Resource.UsernameMustContainOnlyLowercase);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Resource.RequiredField)
            .MinimumLength(8).WithMessage(Resource.PasswordBoundaries)
            .MaximumLength(32).WithMessage(Resource.PasswordBoundaries)
            .Matches(@"[A-Z]+").WithMessage(Resource.PasswordCharacters)
            .Matches(@"[a-z]+").WithMessage(Resource.PasswordCharacters)
            .Matches(@"[0-9]+").WithMessage(Resource.PasswordCharacters)
            .Matches(@"[\!\?\*\.]+").WithMessage(Resource.PasswordCharacters);
    }
}