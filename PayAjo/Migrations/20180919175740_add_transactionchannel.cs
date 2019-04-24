using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAjo.Migrations
{
    public partial class add_transactionchannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionChannel",
                table: "TransactionLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionChannel",
                table: "Transaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionChannel",
                table: "TransactionLog");

            migrationBuilder.DropColumn(
                name: "TransactionChannel",
                table: "Transaction");
        }
    }
}
