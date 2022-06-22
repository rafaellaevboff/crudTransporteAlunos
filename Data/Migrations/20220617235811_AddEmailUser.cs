using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddEmailUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "matricula",
                table: "user",
                newName: "userName");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user",
                type: "NVARCHAR",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "user",
                newName: "matricula");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "nome");
        }
    }
}
