using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class SwapAdvAndAdvimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_files_ImageId",
                table: "advertisment");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_ImageId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "advertisment");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_files_AdvertisementId",
                table: "files",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_files_advertisment_AdvertisementId",
                table: "files",
                column: "AdvertisementId",
                principalTable: "advertisment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_advertisment_AdvertisementId",
                table: "files");

            migrationBuilder.DropIndex(
                name: "IX_files_AdvertisementId",
                table: "files");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "files");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "advertisment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_ImageId",
                table: "advertisment",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_files_ImageId",
                table: "advertisment",
                column: "ImageId",
                principalTable: "files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
