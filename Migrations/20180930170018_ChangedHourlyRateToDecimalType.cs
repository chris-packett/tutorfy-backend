using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorfybackend.Migrations
{
    public partial class ChangedHourlyRateToDecimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "HourlyRate",
                table: "Tutors",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HourlyRate",
                table: "Tutors",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
