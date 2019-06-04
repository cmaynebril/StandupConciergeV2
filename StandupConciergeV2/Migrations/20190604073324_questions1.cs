﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class questions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
