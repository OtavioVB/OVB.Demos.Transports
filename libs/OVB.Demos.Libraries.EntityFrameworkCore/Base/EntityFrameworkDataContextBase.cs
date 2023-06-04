using Microsoft.EntityFrameworkCore;

namespace OVB.Demos.Libraries.EntityFrameworkCore.Base;

public abstract class EntityFrameworkDataContextBase : DbContext
{
    #region Properties

    protected string ConnectionString { get; init; }

    #endregion

    protected EntityFrameworkDataContextBase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        OnConfiguringInternal(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingInternal(modelBuilder);
    }

    protected abstract void OnModelCreatingInternal(ModelBuilder modelBuilder);
    protected abstract void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder);
}
