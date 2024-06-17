namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ApplicationDbContext Context;

    public UnitOfWork(ApplicationDbContext context)
    {
        Context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return Context.SaveChangesAsync(cancellationToken);
    }
}