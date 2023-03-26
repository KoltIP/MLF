using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class Add_City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "advertisment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_CityId",
                table: "advertisment",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_city_Uid",
                table: "city",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_city_CityId",
                table: "advertisment",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_city_CityId",
                table: "advertisment");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_CityId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "advertisment");
        }
    }
}
