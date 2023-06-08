using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.Migrations
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
                    DocumentType = table.Column<string>(type: "CHAR(1)", fixedLength: true, maxLength: 1, nullable: false),
                    DocumentContent = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Documents = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    PlatformName = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    RealName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "CHAR(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Country = table.Column<string>(type: "CHAR(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SourcePlatform = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_IDENTIFIER", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentType = table.Column<string>(type: "CHAR(1)", fixedLength: true, maxLength: 1, nullable: false),
                    DocumentContent = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    OwnerDocuments = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "CHAR(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Country = table.Column<string>(type: "CHAR(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CompanyIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SourcePlatform = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_IDENTIFIER", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_1_COMPANY_N_OWNERS",
                        column: x => x.CompanyIdentifier,
                        principalTable: "Companies",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerAuthentication",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "CHAR(128)", fixedLength: true, maxLength: 128, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "BOOLEAN", fixedLength: true, nullable: false),
                    IsActivatedAccess = table.Column<bool>(type: "BOOLEAN", fixedLength: true, nullable: false),
                    OwnerIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SourcePlatform = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNERAUTHENTICATION_IDENTIFIER", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_1_OWNERAUTHENTCATION_1_OWNER",
                        column: x => x.OwnerIdentifier,
                        principalTable: "Owners",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerPhones",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Ddi = table.Column<string>(type: "CHAR(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Dd = table.Column<string>(type: "CHAR(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    OwnerIdentifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNERPHONE_IDENTIFIER", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_N_OWNERPHONES_1_OWNER",
                        column: x => x.OwnerIdentifier,
                        principalTable: "Owners",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UK_COMPANY_DOCUMENT",
                table: "Companies",
                columns: new[] { "DocumentContent", "DocumentType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerAuthentication_OwnerIdentifier",
                table: "OwnerAuthentication",
                column: "OwnerIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_OWNERAUTHENTICATION_EMAIL",
                table: "OwnerAuthentication",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_OWNERAUTHENTICATION_UESRNAME",
                table: "OwnerAuthentication",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPhones_OwnerIdentifier",
                table: "OwnerPhones",
                column: "OwnerIdentifier");

            migrationBuilder.CreateIndex(
                name: "UK_OWNERPHONE_PHONE",
                table: "OwnerPhones",
                columns: new[] { "Ddi", "Dd", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CompanyIdentifier",
                table: "Owners",
                column: "CompanyIdentifier");

            migrationBuilder.CreateIndex(
                name: "UK_OWNER_DOCUMENTTYPE_AND_DOCUMENTCONTENT",
                table: "Owners",
                columns: new[] { "DocumentType", "DocumentContent" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerAuthentication");

            migrationBuilder.DropTable(
                name: "OwnerPhones");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
