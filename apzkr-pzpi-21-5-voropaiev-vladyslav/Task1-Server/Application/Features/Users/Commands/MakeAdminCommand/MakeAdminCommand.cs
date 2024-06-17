namespace Application.Features.Users.Commands.MakeAdminCommand;

public record MakeAdminCommand(Guid UserId) : IRequest<Guid>;