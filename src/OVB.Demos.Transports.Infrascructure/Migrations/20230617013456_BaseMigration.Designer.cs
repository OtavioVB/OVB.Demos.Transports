﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore;

#nullable disable

namespace OVB.Demos.Transports.Infrascructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230617013456_BaseMigration")]
    partial class BaseMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject.Company", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("CHAR")
                        .HasColumnName("Cnpj")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATE")
                        .HasColumnName("CreatedAt")
                        .IsFixedLength();

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("PlatformName")
                        .IsFixedLength(false);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("RealName")
                        .IsFixedLength(false);

                    b.Property<char>("TypeCompany")
                        .HasMaxLength(1)
                        .HasColumnType("CHAR")
                        .HasColumnName("TypeCompany")
                        .IsFixedLength();

                    b.HasKey("Identifier")
                        .HasName("PK_COMPANY_IDENTIFIER");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasDatabaseName("UK_COMPANY_CNPJ");

                    b.ToTable("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
