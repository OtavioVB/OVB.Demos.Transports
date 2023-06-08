namespace OVB.Demos.Transports.CompanyContext.Infrascructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task AddChangesToTransaction(CancellationToken cancellationToken);
    public Task<TResponse> ExecuteUnitOfWorkAsync<TResponse>(Func<CancellationToken, Task<(bool ExecuteUnit, TResponse Response)>> handler, CancellationToken cancellationToken);
}
