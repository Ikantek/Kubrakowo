using Microsoft.EntityFrameworkCore.Migrations;

namespace Kubrakowo.WebApp.Domain.Migrations
{
    public partial class PriceOnOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offer");
        }
    }
}
