namespace Application.Features.Users.Commands.RegisterWorkerCommand;

public record RegisterWorkerCommand(string FullName, string Username, string Email, string Password) : IRequest<string>;