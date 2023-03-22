using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class FileContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "files",
                newName: "ImageDataUrl");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "files");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "files");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "files");

            migrationBuilder.RenameColumn(
                name: "ImageDataUrl",
                table: "files",
                newName: "Path");
        }
    }
}
