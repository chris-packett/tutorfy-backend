using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorfybackend.Migrations
{
    public partial class ChangedBoolsToPascalCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isTutor",
                table: "Users",
                newName: "IsTutor");

            migrationBuilder.RenameColumn(
                name: "isStudent",
                table: "Users",
                newName: "IsStudent");

            migrationBuilder.RenameColumn(
                name: "isProfileCompleted",
                table: "Users",
                newName: "IsProfileCompleted");

            migrationBuilder.RenameColumn(
                name: "isActivated",
                table: "Users",
                newName: "IsActivated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsTutor",
                table: "Users",
                newName: "isTutor");

            migrationBuilder.RenameColumn(
                name: "IsStudent",
                table: "Users",
                newName: "isStudent");

            migrationBuilder.RenameColumn(
                name: "IsProfileCompleted",
                table: "Users",
                newName: "isProfileCompleted");

            migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "Users",
                newName: "isActivated");
        }
    }
}
