namespace Application.Features.Ponds.Commands.Import;

public sealed class ImportPondsCommandHandler : IRequestHandler<ImportPondsCommand>
{
    private readonly IPondRepository _pondRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ImportPondsCommandHandler(IPondRepository pondRepository, IUnitOfWork unitOfWork)
    {
        _pondRepository = pondRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ImportPondsCommand request, CancellationToken cancellationToken)
    {
        await _pondRepository.ImportFromJsonAsync(request.JsonContent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}