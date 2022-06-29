using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookingservice.Migrations
{
    public partial class altertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dateofjourney",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dateofjourney",
                table: "Tickets");
        }
    }
}
