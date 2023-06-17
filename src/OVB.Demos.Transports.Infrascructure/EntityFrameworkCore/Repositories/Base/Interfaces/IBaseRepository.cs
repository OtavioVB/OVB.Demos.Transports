namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task AddRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken);
}
