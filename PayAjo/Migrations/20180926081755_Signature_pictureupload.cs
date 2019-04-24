using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAjo.Migrations
{
    public partial class Signature_pictureupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureContentLength",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PictureContentType",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignatureContentLength",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SignatureContentType",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignaturePath",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureContentLength",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PictureContentType",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SignatureContentLength",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SignatureContentType",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SignaturePath",
                table: "Customer");
        }
    }
}
