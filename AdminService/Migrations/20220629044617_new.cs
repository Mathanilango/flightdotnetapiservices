using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adminservice.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
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
                    table.PrimaryKey("PK_Airline", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
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
                    Instrument = table.Column<string>(nullable: true),
                    BusinessSeat = table.Column<int>(nullable: false),
                    NonBusinessSeat = table.Column<int>(nullable: false),
                    RoundTrip = table.Column<bool>(nullable: false),
                    TicketCost = table.Column<int>(nullable: false),
                    AvailableBusinessSeat = table.Column<int>(nullable: false),
                    AvailableNonBusinessSeat = table.Column<int>(nullable: false),
                    Couponcode = table.Column<string>(nullable: true),
                    Couponcodeamt = table.Column<int>(nullable: false),
                    BusinessSeatCost = table.Column<int>(nullable: false),
                    NonBusinessSeatCost = table.Column<int>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Datecreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Flightnumber);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airline",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airline");
        }
    }
}
