namespace Application.Features.Users.Commands.DeleteUserCommand;

public record DeleteUserCommand(Guid UserId) : IRequest<Guid>;