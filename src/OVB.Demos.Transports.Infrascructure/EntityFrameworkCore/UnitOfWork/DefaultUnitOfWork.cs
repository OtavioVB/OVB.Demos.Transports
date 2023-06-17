using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;

namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public DefaultUnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddChangesToTransaction(CancellationToken cancellationToken)
        => _dataContext.SaveChangesAsync(cancellationToken);

    public async Task<TResult> ExecuteUnitOfWorkAsync<TResult>(Func<CancellationToken, (bool ExecuteUnitOfWork, TResult Result)> handler, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync();

        var handlerResponse = await handler(cancellationToken);

        if (handlerResponse.HasDone == false)
        {
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Output;
        }
        else
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Output;
        }
    }
}
