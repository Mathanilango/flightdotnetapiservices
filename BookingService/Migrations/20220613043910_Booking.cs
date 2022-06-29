using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookingservice.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pnrno = table.Column<string>(nullable: true, computedColumnSql: "N'PNR'+ RIGHT('00000'+CAST(ID AS VARCHAR(5)),5)"),
                    FlightId = table.Column<int>(nullable: false),
                    AirlineId = table.Column<int>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    BookedSeats = table.Column<int>(nullable: false),
                    Meal = table.Column<string>(nullable: true),
                    Removed = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TicketcancelledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
