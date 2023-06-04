using Microsoft.EntityFrameworkCore;
using OVB.Demos.Libraries.EntityFrameworkCore.Base;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerAuthenticationContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore;

public sealed class CompanyDataContext : EntityFrameworkDataContextBase
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<OwnerPhone> OwnerPhones { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<OwnerAuthentication> OwnerAuthentication { get; set; }

    public CompanyDataContext(string connectionString) : base(connectionString)
    {
    }

    protected override void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString, p => p.MigrationsAssembly("OVB.Demos.Transports.CompanyContext.Infrascructure"));
    }

    protected override void OnModelCreatingInternal(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}
