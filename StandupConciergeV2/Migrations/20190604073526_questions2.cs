using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class questions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionsQuestionId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionsQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Questions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsQuestion", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionsQuestion_QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionsQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionsQuestionId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
