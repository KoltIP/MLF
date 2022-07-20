using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Db.Context.Migrations
{
    public partial class advertisment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_pets_PetId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_users_OwnerId1",
                table: "Advertisement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_OwnerId1",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "Advertisement",
                newName: "advertisment");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_Uid",
                table: "advertisment",
                newName: "IX_advertisment_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_PetId",
                table: "advertisment",
                newName: "IX_advertisment_PetId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "pets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "advertisment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_advertisment",
                table: "advertisment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_advertisment_UserId",
                table: "advertisment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_pets_PetId",
                table: "advertisment",
                column: "PetId",
                principalTable: "pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisment_users_UserId",
                table: "advertisment",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_pets_PetId",
                table: "advertisment");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisment_users_UserId",
                table: "advertisment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advertisment",
                table: "advertisment");

            migrationBuilder.DropIndex(
                name: "IX_advertisment_UserId",
                table: "advertisment");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "advertisment");

            migrationBuilder.RenameTable(
                name: "advertisment",
                newName: "Advertisement");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_Uid",
                table: "Advertisement",
                newName: "IX_Advertisement_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_advertisment_PetId",
                table: "Advertisement",
                newName: "IX_Advertisement_PetId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "pets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId1",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_OwnerId1",
                table: "Advertisement",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_pets_PetId",
                table: "Advertisement",
                column: "PetId",
                principalTable: "pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_users_OwnerId1",
                table: "Advertisement",
                column: "OwnerId1",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
