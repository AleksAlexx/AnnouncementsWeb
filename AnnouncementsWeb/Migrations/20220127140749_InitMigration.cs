using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnnouncementsWeb.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAnnouncements",
                columns: table => new
                {
                    AnnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    DateTimeCreation = table.Column<DateTime>(nullable: false),
                    NameOfAnn = table.Column<string>(maxLength: 200, nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAnnouncements", x => x.AnnId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAnnouncements");
        }
    }
}
