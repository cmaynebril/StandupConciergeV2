using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class questions4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionsQuestion_QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "QuestionsQuestion",
                newName: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsQuestion_QuestionId",
                table: "QuestionsQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsQuestion_Questions_QuestionId",
                table: "QuestionsQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsQuestion_Questions_QuestionId",
                table: "QuestionsQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsQuestion_QuestionId",
                table: "QuestionsQuestion");

            migrationBuilder.RenameColumn(
                name: "Questions",
                table: "QuestionsQuestion",
                newName: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuestionsQuestionId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionsQuestionId",
                table: "Questions",
                column: "QuestionsQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionsQuestion_QuestionsQuestionId",
                table: "Questions",
                column: "QuestionsQuestionId",
                principalTable: "QuestionsQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
