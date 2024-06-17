namespace Application.Features.Ponds.Queries.Export;

public sealed class ExportPondsQueryHandler : IRequestHandler<ExportPondsQuery, string>
{
    private readonly IPondRepository _pondRepository;

    public ExportPondsQueryHandler(IPondRepository pondRepository)
    {
        _pondRepository = pondRepository;
    }

    public async Task<string> Handle(ExportPondsQuery request, CancellationToken cancellationToken)
    {
        return await _pondRepository.ExportToJsonAsync(cancellationToken); 
    }
}