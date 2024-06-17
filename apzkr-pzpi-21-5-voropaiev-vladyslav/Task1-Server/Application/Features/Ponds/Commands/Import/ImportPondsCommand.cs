namespace Application.Features.Ponds.Commands.Import;

public record ImportPondsCommand(string JsonContent) : IRequest;