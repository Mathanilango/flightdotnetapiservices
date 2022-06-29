using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookingservice.Migrations
{
    public partial class altertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Meal",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PassengerName",
                table: "Tickets",
                newName: "Seattype");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seattype",
                table: "Tickets",
                newName: "PassengerName");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Meal",
                table: "Tickets",
                nullable: true);
        }
    }
}
