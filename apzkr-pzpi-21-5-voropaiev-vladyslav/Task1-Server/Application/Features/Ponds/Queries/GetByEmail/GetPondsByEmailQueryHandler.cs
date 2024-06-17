namespace Application.Features.Ponds.Queries.GetByEmail;

public class GetPondsByEmailQueryHandler : IRequestHandler<GetPondsByEmailQuery, List<PondResponse>>
{
    private readonly IPondRepository _pondRepository;
    private readonly IMapper _mapper;

    public GetPondsByEmailQueryHandler(IPondRepository pondRepository, IMapper mapper)
    {
        _pondRepository = pondRepository;
        _mapper = mapper;
    }

    public async Task<List<PondResponse>> Handle(GetPondsByEmailQuery request, CancellationToken cancellationToken)
    {
        var response = await _pondRepository.GetByEmailAsync(request.Email, cancellationToken);
        return _mapper.Map<List<PondResponse>>(response);
    }
}