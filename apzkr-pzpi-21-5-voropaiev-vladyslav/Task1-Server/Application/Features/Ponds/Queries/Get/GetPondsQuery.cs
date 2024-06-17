namespace Application.Features.Ponds.Queries.Get;

public record GetPondsQuery() : IRequest<List<Pond>>;