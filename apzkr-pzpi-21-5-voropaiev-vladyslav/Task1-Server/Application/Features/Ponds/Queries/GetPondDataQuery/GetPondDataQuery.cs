namespace Application.Features.Ponds.Queries.GetPondDataQuery;

public record GetPondDataQuery(Guid PondId) : IRequest<object>;