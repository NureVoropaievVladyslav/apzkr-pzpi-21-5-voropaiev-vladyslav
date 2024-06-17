namespace Application.Features.Users.Commands.RegisterWorkerCommand;

public class RegisterWorkerCommandProfile : Profile
{
    public RegisterWorkerCommandProfile()
    {
        CreateMap<RegisterWorkerCommand, User>();
    }
}