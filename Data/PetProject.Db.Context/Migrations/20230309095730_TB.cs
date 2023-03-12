using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class TB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_breeds_PetBreedId",
                table: "advertisment");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_PetBreedId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "PetBreedId",
                table: "advertisment");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "breeds",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_breeds_TypeId",
                table: "breeds",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_breeds_typies_TypeId",
                table: "breeds",
                column: "TypeId",
                principalTable: "typies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_breeds_typies_TypeId",
                table: "breeds");

            migrationBuilder.DropIndex(
                name: "IX_breeds_TypeId",
                table: "breeds");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "breeds");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "advertisment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PetBreedId",
                table: "advertisment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_PetBreedId",
                table: "advertisment",
                column: "PetBreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_breeds_PetBreedId",
                table: "advertisment",
                column: "PetBreedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
