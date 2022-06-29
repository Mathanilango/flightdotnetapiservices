using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Searchservice.Migrations
{
    public partial class azuredb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airline",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    blocked = table.Column<bool>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Datecreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airline", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pnrno = table.Column<string>(nullable: true, computedColumnSql: "N'PNR'+ RIGHT('00000'+CAST(ID AS VARCHAR(5)),5)"),
                    FlightId = table.Column<int>(nullable: false),
                    AirlineId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BookedSeats = table.Column<int>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Dateofjourney = table.Column<DateTime>(nullable: false),
                    TicketcancelledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    Flightnumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineId = table.Column<int>(nullable: false),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ScheduleDays = table.Column<string>(nullable: true),
                    RoundTrip = table.Column<bool>(nullable: false),
                    Instrument = table.Column<string>(nullable: true),
                    BusinessSeat = table.Column<int>(nullable: false),
                    NonBusinessSeat = table.Column<int>(nullable: false),
                    AvailableBusinessSeat = table.Column<int>(nullable: false),
                    AvailableNonBusinessSeat = table.Column<int>(nullable: false),
                    Couponcode = table.Column<string>(nullable: true),
                    Couponcodeamt = table.Column<int>(nullable: false),
                    TicketCost = table.Column<int>(nullable: false),
                    BusinessSeatCost = table.Column<int>(nullable: false),
                    NonBusinessSeatCost = table.Column<int>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Datecreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight", x => x.Flightnumber);
                    table.ForeignKey(
                        name: "FK_flight_airline_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airline",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flight_AirlineId",
                table: "flight",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "airline");
        }
    }
}
