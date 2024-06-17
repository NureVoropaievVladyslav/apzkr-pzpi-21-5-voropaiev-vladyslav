namespace Application.Features.Ponds.Queries.GetPondDataQuery;

public sealed class GetPondDataQueryHandler : IRequestHandler<GetPondDataQuery, object>
{
    private readonly IPondRepository _pondRepository;
    private readonly IMapper _mapper;

    public GetPondDataQueryHandler(IPondRepository pondRepository, IMapper mapper)
    {
        _pondRepository = pondRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetPondDataQuery request, CancellationToken cancellationToken)
    {
        var pondData = await _pondRepository.GetDataAsync(request.PondId, cancellationToken);
        return pondData;
    }
}