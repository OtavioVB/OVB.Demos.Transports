using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Mappings;

public sealed class OwnerMapping : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        #region Primary Key's
        builder.HasKey(p => p.Identifier).HasName("PK_OWNER_IDENTIFIER");
        #endregion

        #region Foreign Key's
        builder
            .HasOne(p => p.Company)
            .WithMany(p => p.Owners)
            .HasForeignKey(p => p.CompanyIdentifier)
            .HasConstraintName("FK_1_COMPANY_N_OWNERS")
            .IsRequired(true);
        #endregion

        #region Index 
        builder.HasIndex(p => new
        {
            p.DocumentType,
            p.DocumentContent
        }).IsUnique().HasDatabaseName("UK_OWNER_DOCUMENTTYPE_AND_DOCUMENTCONTENT");
        #endregion

        #region Properties
        builder.Property(p => p.OwnerDocuments)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("OwnerDocuments")
            .HasColumnType("BINARY")
            .ValueGeneratedNever();

        builder.Property(p => p.DocumentType)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnName("DocumentType")
            .HasColumnType("CHAR")
            .HasMaxLength(1)
            .ValueGeneratedNever();

        builder.Property(p => p.DocumentContent)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("DocumentContent")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .ValueGeneratedNever();

        builder.Property(p => p.LastName)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("LastName")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .ValueGeneratedNever();

        builder.Property(p => p.Language)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnName("Language")
            .HasColumnType("CHAR")
            .HasMaxLength(5)
            .ValueGeneratedNever();

        builder.Property(p => p.Country)
            .IsRequired(true)
            .IsFixedLength(true)
            .HasColumnName("Country")
            .HasColumnType("CHAR")
            .HasMaxLength(3)
            .ValueGeneratedNever();
        #endregion
    }
}
