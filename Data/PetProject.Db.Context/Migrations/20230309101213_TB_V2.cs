using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class TB_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "typies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_typies_BreedId",
                table: "typies",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_typies_breeds_BreedId",
                table: "typies",
                column: "BreedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_typies_breeds_BreedId",
                table: "typies");

            migrationBuilder.DropIndex(
                name: "IX_typies_BreedId",
                table: "typies");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "typies");

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
    }
}
