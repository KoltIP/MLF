using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class IsWantedAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWanted",
                table: "advertisment",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWanted",
                table: "advertisment");
        }
    }
}
