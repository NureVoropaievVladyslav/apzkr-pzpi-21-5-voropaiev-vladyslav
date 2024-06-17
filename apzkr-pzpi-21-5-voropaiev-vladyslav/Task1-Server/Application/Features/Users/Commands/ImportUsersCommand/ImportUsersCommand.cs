namespace Application.Features.Users.Commands.ImportUsersCommand;

public record ImportUsersCommand(string JsonContent) : IRequest;