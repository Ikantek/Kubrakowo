using Microsoft.EntityFrameworkCore.Migrations;

namespace Kubrakowo.WebApp.Domain.Migrations
{
    public partial class SizeAndLocalizationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Size",
                table: "Offers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Offers");
        }
    }
}
