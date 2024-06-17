namespace Application.Features.Ponds.Commands.Delete;

public record DeletePondCommand(Guid PondId) : IRequest;