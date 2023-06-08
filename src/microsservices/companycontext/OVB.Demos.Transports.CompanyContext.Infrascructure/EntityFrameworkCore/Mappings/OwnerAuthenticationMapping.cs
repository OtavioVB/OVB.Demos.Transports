using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerAuthenticationContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Mappings;

public sealed class OwnerAuthenticationMapping : IEntityTypeConfiguration<OwnerAuthentication>
{
    public void Configure(EntityTypeBuilder<OwnerAuthentication> builder)
    {
        #region Primary Key's
        builder.HasKey(p => p.Identifier).HasName("PK_OWNERAUTHENTICATION_IDENTIFIER");
        #endregion

        #region Foreign Key's 
        builder.HasOne(p => p.Owner)
            .WithOne(p => p.OwnerAuthentication)
            .HasForeignKey<OwnerAuthentication>(p => p.OwnerIdentifier)
            .HasConstraintName("FK_1_OWNERAUTHENTCATION_1_OWNER")
            .IsRequired(true);
        #endregion

        #region Indexes 
        builder.HasIndex(p => p.Email).IsUnique().HasDatabaseName("UK_OWNERAUTHENTICATION_EMAIL");
        builder.HasIndex(p => p.Username).IsUnique().HasDatabaseName("UK_OWNERAUTHENTICATION_UESRNAME");
        #endregion

        #region Properties
        builder.Property(p => p.Username)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("Username")
            .HasColumnType("VARCHAR")
            .HasMaxLength(32)
            .ValueGeneratedNever();

        builder.Property(p => p.Email)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .ValueGeneratedNever();

        builder.Property(p => p.Password)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnName("Password")
            .HasColumnType("CHAR")
            .HasMaxLength(128)
            .ValueGeneratedNever();

        builder.Property(p => p.IsEmailConfirmed)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnType("IsEmailConfirmed")
            .HasColumnType("BOOLEAN")
            .ValueGeneratedNever();

        builder.Property(p => p.IsActivatedAccess)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnType("IsActivatedAccess")
            .HasColumnType("BOOLEAN")
            .ValueGeneratedNever();
        #endregion
    }
}
