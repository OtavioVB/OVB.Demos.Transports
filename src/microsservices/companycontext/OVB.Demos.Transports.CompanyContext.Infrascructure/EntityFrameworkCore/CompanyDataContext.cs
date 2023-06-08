using Microsoft.EntityFrameworkCore;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerAuthenticationContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Mappings;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore;

public sealed class CompanyDataContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    public DbSet<OwnerPhone> OwnerPhones { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<OwnerAuthentication> OwnerAuthentication { get; set; }

    public CompanyDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyMapping());
        modelBuilder.ApplyConfiguration(new OwnerPhoneMapping());
        modelBuilder.ApplyConfiguration(new OwnerMapping());
        modelBuilder.ApplyConfiguration(new OwnerAuthenticationMapping());
        base.OnModelCreating(modelBuilder);
    }
}
