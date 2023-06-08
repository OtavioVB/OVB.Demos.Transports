using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Mappings;

public sealed class OwnerPhoneMapping : IEntityTypeConfiguration<OwnerPhone>
{
    public void Configure(EntityTypeBuilder<OwnerPhone> builder)
    {
        #region Primary Key's
        builder.HasKey(p => p.Identifier).HasName("PK_OWNERPHONE_IDENTIFIER");
        #endregion

        #region Foreign Key's
        builder.HasOne(p => p.Owner)
            .WithMany(p => p.OwnerPhones)
            .HasForeignKey(p => p.OwnerIdentifier)
            .HasConstraintName("FK_N_OWNERPHONES_1_OWNER")
            .IsRequired(true);
        #endregion

        #region Indexes
        builder.HasIndex(p => new
        {
            p.Ddi,
            p.Dd,
            p.Number
        }).IsUnique().HasDatabaseName("UK_OWNERPHONE_PHONE");
        #endregion

        #region Properties
        builder.Property(p => p.Ddi)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnType("CHAR")
            .HasColumnName("Ddi")
            .HasMaxLength(4)
            .ValueGeneratedNever();

        builder.Property(p => p.Dd)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnType("CHAR")
            .HasColumnName("Dd")
            .HasMaxLength(4)
            .ValueGeneratedNever();

        builder.Property(p => p.Number)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnType("VARCHAR")
            .HasColumnName("Number")
            .HasMaxLength(32)
            .ValueGeneratedNever();
        #endregion
    }
}
