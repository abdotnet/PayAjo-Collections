using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAjo.Migrations
{
    public partial class addtransactionlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionLog",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionNo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    TransactionCode = table.Column<string>(nullable: true),
                    MerchantId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: true),
                    IsNotified = table.Column<bool>(nullable: false),
                    CollectionTypeId = table.Column<long>(nullable: true),
                    TransactionMapCode = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLog_CollectionType_CollectionTypeId",
                        column: x => x.CollectionTypeId,
                        principalTable: "CollectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLog_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLog_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLog_CollectionTypeId",
                table: "TransactionLog",
                column: "CollectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLog_CustomerId",
                table: "TransactionLog",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLog_MerchantId",
                table: "TransactionLog",
                column: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLog");
        }
    }
}
