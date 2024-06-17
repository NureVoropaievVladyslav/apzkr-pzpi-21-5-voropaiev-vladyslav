namespace Application.Features.Ponds.Commands.Delete;

public sealed class DeletePondCommandHandler : IRequestHandler<DeletePondCommand>
{
    private readonly IPondRepository _pondRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePondCommandHandler(IPondRepository pondRepository, IUnitOfWork unitOfWork)
    {
        _pondRepository = pondRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePondCommand request, CancellationToken cancellationToken)
    {
        var pond = await _pondRepository.GetAsync(request.PondId, cancellationToken);
        _pondRepository.Delete(pond!);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}