using Microsoft.EntityFrameworkCore;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;

namespace OVB.Demos.Transports.Infrascructure;

public sealed class DataContext : DbContext
{
    public DbSet<Company> Companies { get; private set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyMapping());

        base.OnModelCreating(modelBuilder);
    }
}
