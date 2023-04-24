using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class AddFilterInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advertisementfilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsWanted = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    PetColorId = table.Column<int>(type: "integer", nullable: true),
                    PetBreedId = table.Column<int>(type: "integer", nullable: true),
                    PetTypeId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    AgeStart = table.Column<int>(type: "integer", nullable: true),
                    AgeEnd = table.Column<int>(type: "integer", nullable: true),
                    DateLostStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateLostEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertisementfilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_advertisementfilter_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advertisementfilter_Uid",
                table: "advertisementfilter",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementfilter_UserId",
                table: "advertisementfilter",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advertisementfilter");
        }
    }
}
