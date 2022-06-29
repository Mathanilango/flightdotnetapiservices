using Microsoft.EntityFrameworkCore.Migrations;

namespace Adminservice.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "users");
        }
    }
}
