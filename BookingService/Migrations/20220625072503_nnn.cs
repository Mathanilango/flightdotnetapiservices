using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookingservice.Migrations
{
    public partial class nnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pnrno = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Meal = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Seatno = table.Column<int>(nullable: false),
                    seattype = table.Column<int>(nullable: false),
                    removed = table.Column<bool>(nullable: false),
                    dateofjourney = table.Column<DateTime>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");
        }
    }
}
