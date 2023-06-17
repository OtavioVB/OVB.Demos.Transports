using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Demos.Transports.Infrascructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformName = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    RealName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Cnpj = table.Column<string>(type: "CHAR(14)", fixedLength: true, maxLength: 14, nullable: false),
                    TypeCompany = table.Column<char>(type: "CHAR(1)", fixedLength: true, maxLength: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATE", fixedLength: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_IDENTIFIER", x => x.Identifier);
                });

            migrationBuilder.CreateIndex(
                name: "UK_COMPANY_CNPJ",
                table: "Companies",
                column: "Cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
