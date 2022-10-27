using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OKR_Steam.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SteamProfile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    uniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    steamid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profilestate = table.Column<int>(type: "int", nullable: false),
                    profileurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryclanid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamProfile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SteamProfile");
        }
    }
}
