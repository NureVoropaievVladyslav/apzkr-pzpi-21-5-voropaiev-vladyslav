namespace Application.Features.Users.Commands.UpdateUserCommand;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty).WithMessage(Resource.RequiredField);
        
        RuleFor(x => x.FullName)
            .MinimumLength(8).WithMessage(Resource.FullNameMustBeEightCharacters).When(x => x.FullName is not null);

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(Resource.EmailNotValid).When(x => x.Email is not null);
        
        RuleFor(x => x.Username)
            .MinimumLength(5).WithMessage(Resource.UsernameMustBeFiveCharacters).When(x => x.Username is not null)
            .Matches("[a-z]+$").WithMessage(Resource.UsernameMustContainOnlyLowercase).When(x => x.Username is not null);
    }
}