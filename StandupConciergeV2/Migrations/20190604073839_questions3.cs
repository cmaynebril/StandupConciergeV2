using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class questions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Questions",
                table: "QuestionsQuestion",
                newName: "Question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "QuestionsQuestion",
                newName: "Questions");
        }
    }
}
