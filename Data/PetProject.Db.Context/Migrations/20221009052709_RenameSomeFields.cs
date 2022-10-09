using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class RenameSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_breeds_BreedId",
                table: "advertisment");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_colors_ColorId",
                table: "advertisment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "advertisment",
                newName: "PetName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "advertisment",
                newName: "PetDescription");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "advertisment",
                newName: "PetColorId");

            migrationBuilder.RenameColumn(
                name: "BreedId",
                table: "advertisment",
                newName: "PetBreedId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_ColorId",
                table: "advertisment",
                newName: "IX_advertisment_PetColorId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_BreedId",
                table: "advertisment",
                newName: "IX_advertisment_PetBreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_breeds_PetBreedId",
                table: "advertisment",
                column: "PetBreedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_colors_PetColorId",
                table: "advertisment",
                column: "PetColorId",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_breeds_PetBreedId",
                table: "advertisment");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_colors_PetColorId",
                table: "advertisment");

            migrationBuilder.RenameColumn(
                name: "PetName",
                table: "advertisment",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PetDescription",
                table: "advertisment",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PetColorId",
                table: "advertisment",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "PetBreedId",
                table: "advertisment",
                newName: "BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_PetColorId",
                table: "advertisment",
                newName: "IX_advertisment_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_PetBreedId",
                table: "advertisment",
                newName: "IX_advertisment_BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_breeds_BreedId",
                table: "advertisment",
                column: "BreedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_colors_ColorId",
                table: "advertisment",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
