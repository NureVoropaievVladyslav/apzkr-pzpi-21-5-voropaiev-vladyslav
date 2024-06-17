namespace Application.Features.Ponds.Queries.Get;

public sealed class GetPondsQueryHandler : IRequestHandler<GetPondsQuery, List<Pond>>
{
    private readonly IPondRepository _pondRepository;

    public GetPondsQueryHandler(IPondRepository pondRepository)
    {
        _pondRepository = pondRepository;
    }

    public async Task<List<Pond>> Handle(GetPondsQuery request, CancellationToken cancellationToken)
    {
        return await _pondRepository.GetAsync(cancellationToken); 
    }
}