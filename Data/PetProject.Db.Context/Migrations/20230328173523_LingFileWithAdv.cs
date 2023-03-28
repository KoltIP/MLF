using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class LingFileWithAdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDataUrl",
                table: "files");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "files");

            migrationBuilder.DropColumn(
                name: "Size",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageDataUrl",
                table: "files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
