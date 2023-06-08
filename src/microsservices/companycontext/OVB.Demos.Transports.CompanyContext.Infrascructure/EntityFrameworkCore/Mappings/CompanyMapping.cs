using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Libraries.Protobuf.Serializator;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Mappings;

public sealed class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        #region Primary Key's
        builder.HasKey(p => p.Identifier).HasName("PK_COMPANY_IDENTIFIER");
        #endregion

        #region Foreign Key's
        #endregion

        #region Indexes
        builder.HasIndex(p => new
        {
            p.DocumentContent,
            p.DocumentType
        }).IsUnique().HasDatabaseName("UK_COMPANY_DOCUMENT");
        #endregion

        #region Properties
        builder.Property(p => p.RealName)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("RealName")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .ValueGeneratedNever();

        builder.Property(p => p.PlatformName)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("PlatformName")
            .HasColumnType("VARCHAR")
            .HasMaxLength(32)
            .ValueGeneratedNever();

        builder.Property(p => p.Documents)
            .IsRequired(true)
            .IsFixedLength(false)
            .HasColumnName("Documents")
            .HasColumnType("BINARY")
            .HasConversion(p => Serializator.SerializeProtobuf(p), p => Serializator.DeserializeProtobuf<CompanyDocument>(p))
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
