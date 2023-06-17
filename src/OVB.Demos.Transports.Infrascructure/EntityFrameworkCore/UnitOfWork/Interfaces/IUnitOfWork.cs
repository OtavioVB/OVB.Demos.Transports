namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task AddChangesToTransaction(CancellationToken cancellationToken);
    public Task<TResult> ExecuteUnitOfWorkAsync<TResult>(Func<CancellationToken, (bool ExecuteUnitOfWork, TResult Result)> handler, CancellationToken cancellationToken);
}
