using Microsoft.EntityFrameworkCore.Migrations;

namespace StandupConciergeV2.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "frequecy",
                table: "Schedules",
                newName: "frequency");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Schedules_ScheduleId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "frequency",
                table: "Schedules",
                newName: "frequecy");

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
    }
}
