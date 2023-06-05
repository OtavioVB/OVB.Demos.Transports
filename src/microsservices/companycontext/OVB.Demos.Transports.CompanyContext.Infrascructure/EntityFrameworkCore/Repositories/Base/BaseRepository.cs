using Microsoft.EntityFrameworkCore;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    protected CompanyDataContext _dataContext;

    protected BaseRepository(CompanyDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        => _dataContext.Set<TEntity>().AddAsync(entity: entity, cancellationToken: cancellationToken).AsTask();

    public Task AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken)
        => _dataContext.Set<TEntity>().AddRangeAsync(entities: entities, cancellationToken: cancellationToken);

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        => Task.Run(action: () => _dataContext.Set<TEntity>().Remove(entity), cancellationToken: cancellationToken);

    public Task DeleteRangeAsync(TEntity[] entities, CancellationToken cancellationToken)
        => Task.Run(action: () => _dataContext.Set<TEntity>().RemoveRange(entities), cancellationToken: cancellationToken);

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        => Task.Run(action: () => _dataContext.Set<TEntity>().Update(entity), cancellationToken: cancellationToken);

    public Task UpdateRangeAsync(TEntity[] entities, CancellationToken cancellationToken)
        => Task.Run(action: () => _dataContext.Set<TEntity>().UpdateRange(entities), cancellationToken: cancellationToken);

    public Task<TEntity?> GetEntityByIdentifierAsync(Guid identifier, CancellationToken cancellationToken)
        => _dataContext.Set<TEntity>().FindAsync(identifier, cancellationToken).AsTask();

    public Task<TEntity?> GetEntityByAnyInformationAsync(string information, CancellationToken cancellationToken)
        => _dataContext.Set<TEntity>().FindAsync(information, cancellationToken).AsTask();
}
