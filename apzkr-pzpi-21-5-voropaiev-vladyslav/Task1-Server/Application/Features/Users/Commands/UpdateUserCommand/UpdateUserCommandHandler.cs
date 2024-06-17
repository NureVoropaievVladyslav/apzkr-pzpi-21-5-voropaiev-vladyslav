namespace Application.Features.Users.Commands.UpdateUserCommand;

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(request.UserId, cancellationToken))!;
        if (request.Email is not null)
        {
            await _userRepository.CheckEmailAvailabilityAsync(request.Email, cancellationToken);
        }

        foreach (var property in typeof(UpdateUserCommand).GetProperties())
        {
            var requestValue = property.GetValue(request);
            if (requestValue == null || string.IsNullOrWhiteSpace(requestValue.ToString())) continue;
            
            var userProperty = user.GetType().GetProperty(property.Name);
            userProperty?.SetValue(user, requestValue);
        }
        
        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}