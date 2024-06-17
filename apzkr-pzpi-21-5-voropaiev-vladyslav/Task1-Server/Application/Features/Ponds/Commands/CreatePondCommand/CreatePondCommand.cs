using Domain.Enums;

namespace Application.Features.Ponds.Commands.CreatePondCommand;

public record CreatePondCommand(FishSpecies FishSpecies, int FishPopulation) : IRequest<Guid>;