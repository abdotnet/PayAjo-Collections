using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAjo.Migrations
{
    public partial class add_merchantcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantCode",
                table: "Merchant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantCode",
                table: "Merchant");
        }
    }
}
