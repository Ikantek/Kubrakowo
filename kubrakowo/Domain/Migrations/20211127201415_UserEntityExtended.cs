using Microsoft.EntityFrameworkCore.Migrations;

namespace Kubrakowo.WebApp.Domain.Migrations
{
    public partial class UserEntityExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsEmailEnabled",
                table: "AspNetUsers");
        }
    }
}
