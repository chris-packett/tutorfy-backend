using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorfybackend.Migrations
{
    public partial class AddedPictureURLFieldToTutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Tutors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Tutors");
        }
    }
}
