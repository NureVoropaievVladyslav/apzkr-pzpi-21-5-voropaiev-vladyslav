namespace Application.Features.Users.Commands.UpdateUserCommand;

public record UpdateUserCommand(Guid UserId, string? FullName, string? Email, string? Username) : IRequest<Guid>;