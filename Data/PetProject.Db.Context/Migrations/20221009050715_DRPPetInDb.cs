using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class DRPPetInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_pets_PetId",
                table: "advertisment");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "advertisment",
                newName: "PetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_PetId",
                table: "advertisment",
                newName: "IX_advertisment_PetTypeId");

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "advertisment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "advertisment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "advertisment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "advertisment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_BreedId",
                table: "advertisment",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_ColorId",
                table: "advertisment",
                column: "ColorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_typies_PetTypeId",
                table: "advertisment",
                column: "PetTypeId",
                principalTable: "typies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_breeds_BreedId",
                table: "advertisment");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_colors_ColorId",
                table: "advertisment");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_typies_PetTypeId",
                table: "advertisment");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_BreedId",
                table: "advertisment");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_ColorId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "advertisment");

            migrationBuilder.RenameColumn(
                name: "PetTypeId",
                table: "advertisment",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_PetTypeId",
                table: "advertisment",
                newName: "IX_advertisment_PetId");

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BreedId = table.Column<int>(type: "integer", nullable: false),
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    PetTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pets_breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pets_colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pets_typies_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "typies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pets_BreedId",
                table: "pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_ColorId",
                table: "pets",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_PetTypeId",
                table: "pets",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_Uid",
                table: "pets",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_pets_PetId",
                table: "advertisment",
                column: "PetId",
                principalTable: "pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
