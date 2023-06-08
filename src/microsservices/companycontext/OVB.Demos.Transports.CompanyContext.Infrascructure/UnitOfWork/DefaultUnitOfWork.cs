using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore;
using OVB.Demos.Transports.CompanyContext.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    private readonly CompanyDataContext _dataContext;

    public DefaultUnitOfWork(CompanyDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddChangesToTransaction(CancellationToken cancellationToken)
    {
        return _dataContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TResponse> ExecuteUnitOfWorkAsync<TResponse>(Func<CancellationToken, Task<(bool ExecuteUnit, TResponse Response)>> handler, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync();

        var handlerResponse = await handler(cancellationToken);

        if (handlerResponse.ExecuteUnit == false)
        {
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Response;
        }
        else
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Response;
        }
    }
}
