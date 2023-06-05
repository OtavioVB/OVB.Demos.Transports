namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteRangeAsync(TEntity[] entities, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateRangeAsync(TEntity[] entities, CancellationToken cancellationToken);
    public Task<TEntity?> GetEntityByIdentifierAsync(Guid identifier, CancellationToken cancellationToken);
    public Task<TEntity?> GetEntityByAnyInformationAsync(string information, CancellationToken cancellationToken);
}
