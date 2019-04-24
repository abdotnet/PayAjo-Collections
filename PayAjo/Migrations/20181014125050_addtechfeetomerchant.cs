using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAjo.Migrations
{
    public partial class addtechfeetomerchant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TechFeeCost",
                table: "Merchant",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechFeeCost",
                table: "Merchant");
        }
    }
}
