using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Domain.CompanyContext.ValueObjects;
using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Mappings;

public sealed class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        #region Primary Key

        builder.HasKey(p => p.Identifier).HasName($"PK_{Company.ToUpper}_{nameof(Company.Identifier).ToUpper()}");

        #endregion

        #region Unique Key's
        builder.HasIndex(p => p.Cnpj).IsUnique().HasDatabaseName($"UK_{Company.ToUpper}_{nameof(Company.Cnpj).ToUpper()}");
        #endregion

        #region Properties

        builder.Property(p => p.RealName)
            .IsFixedLength(Name.IsFixedLength)
            .IsRequired(true)
            .HasColumnName(nameof(Company.RealName))
            .HasColumnType(Name.DatabaseColumnType)
            .HasMaxLength(Name.MaxLength)
            .ValueGeneratedNever();

        builder.Property(p => p.PlatformName)
            .IsFixedLength(PlatformName.IsFixedLength)
            .IsRequired(true)
            .HasColumnName(nameof(Company.PlatformName))
            .HasColumnType(PlatformName.DatabaseColumnType)
            .HasMaxLength(PlatformName.MaxLength)
            .ValueGeneratedNever();

        builder.Property(p => p.Cnpj)
            .IsFixedLength(Cnpj.IsFixedLength)
            .IsRequired(true)
            .HasColumnName(nameof(Company.Cnpj))
            .HasColumnType(Cnpj.DatabaseColumnType)
            .HasMaxLength(Cnpj.UniqueLength)
            .ValueGeneratedNever();

        builder.Property(p => p.TypeCompany)
            .IsFixedLength(true)
            .IsRequired(true)
            .HasColumnName(nameof(Company.TypeCompany))
            .HasColumnType("CHAR")
            .HasMaxLength(1)
            .ValueGeneratedNever();

        builder.Property(p => p.CreatedAt)
            .IsFixedLength(true)
            .IsRequired(true)
            .HasColumnName(nameof(Company.CreatedAt))
            .HasColumnType("DATE")
            .ValueGeneratedNever();

        #endregion
    }
}
