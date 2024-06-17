namespace Application.Features.Ponds.Commands.CreatePondCommand;

public class CreatePondCommandProfile : Profile
{
    public CreatePondCommandProfile()
    {
        CreateMap<CreatePondCommand, Pond>();
    }
}