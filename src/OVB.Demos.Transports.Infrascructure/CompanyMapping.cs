using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;

namespace OVB.Demos.Transports.Infrascructure;

public sealed class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        #region Primary Key
        builder.HasKey(p => p.Identifier).HasName($"PK_{Company.ToUpper}_{nameof(Company.Identifier).ToUpper()}");
        #endregion

        #region Properties

        builder.Property(p => p.Cnpj)
            .IsFixedLength(true)
            .IsRequired(true)
            .HasColumnName(nameof(Company.Cnpj))
            .HasColumnType("CHAR")
            .HasMaxLength(14)
            .ValueGeneratedNever();
            
        #endregion
    }
}
