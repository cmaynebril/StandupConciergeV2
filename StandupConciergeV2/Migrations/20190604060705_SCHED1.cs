using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class SCHED1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
