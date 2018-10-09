using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorfybackend.Migrations
{
    public partial class RemovedIsTutorIsStudentAndAnswerFourAndFiveFromQuizTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerFive",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerFour",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IsTutor",
                table: "Quizzes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerFive",
                table: "Quizzes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerFour",
                table: "Quizzes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Quizzes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTutor",
                table: "Quizzes",
                nullable: false,
                defaultValue: false);
        }
    }
}
