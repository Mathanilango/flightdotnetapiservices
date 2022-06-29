using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookingservice.Migrations
{
    public partial class tttsh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "seattype",
                table: "passengers",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "seattype",
                table: "passengers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
