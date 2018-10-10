using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorfybackend.Migrations
{
    public partial class AddedQuizFKToStudentAndTutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Tutors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_QuizId",
                table: "Tutors",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_QuizId",
                table: "Students",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Quizzes_QuizId",
                table: "Students",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_Quizzes_QuizId",
                table: "Tutors",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Quizzes_QuizId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_Quizzes_QuizId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_QuizId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Students_QuizId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Students");
        }
    }
}
