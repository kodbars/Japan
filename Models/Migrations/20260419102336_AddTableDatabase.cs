using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models_DB_and_Request.Migrations
{
    /// <inheritdoc />
    public partial class AddTableDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalMenu = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CacheDayExternalMenu = table.Column<DateTime>(type: "DATETIME2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMenus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityMenus_Lookup",
                table: "CityMenus",
                columns: new[] { "City", "OrganizationId", "ExternalMenuId", "CacheDayExternalMenu" });

            migrationBuilder.CreateIndex(
                name: "IX_CityMenus_Unique",
                table: "CityMenus",
                columns: new[] { "City", "OrganizationId", "ExternalMenuId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityMenus");
        }
    }
}
