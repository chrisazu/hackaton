using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DietGoalExercisesGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_HealthyUsers_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_GoalId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_GoalId1",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameColumn(
                name: "GoalId1",
                table: "Progresses",
                newName: "ExercisesGoalId");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Progresses",
                newName: "DietGoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_GoalId1",
                table: "Progresses",
                newName: "IX_Progresses_ExercisesGoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_GoalId",
                table: "Progresses",
                newName: "IX_Progresses_DietGoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_UserId",
                table: "Goal",
                newName: "IX_Goal_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "TimesPerFrequency",
                table: "Goal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Kilograms",
                table: "Goal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Frequency",
                table: "Goal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Goal",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Goal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goal",
                table: "Goal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_HealthyUsers_UserId",
                table: "Goal",
                column: "UserId",
                principalTable: "HealthyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goal_DietGoalId",
                table: "Progresses",
                column: "DietGoalId",
                principalTable: "Goal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goal_ExercisesGoalId",
                table: "Progresses",
                column: "ExercisesGoalId",
                principalTable: "Goal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_HealthyUsers_UserId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goal_DietGoalId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goal_ExercisesGoalId",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goal",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Goal");

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameColumn(
                name: "ExercisesGoalId",
                table: "Progresses",
                newName: "GoalId1");

            migrationBuilder.RenameColumn(
                name: "DietGoalId",
                table: "Progresses",
                newName: "GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_ExercisesGoalId",
                table: "Progresses",
                newName: "IX_Progresses_GoalId1");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_DietGoalId",
                table: "Progresses",
                newName: "IX_Progresses_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_UserId",
                table: "Goals",
                newName: "IX_Goals_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "TimesPerFrequency",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kilograms",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Frequency",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Goals",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_HealthyUsers_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "HealthyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goals_GoalId",
                table: "Progresses",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goals_GoalId1",
                table: "Progresses",
                column: "GoalId1",
                principalTable: "Goals",
                principalColumn: "Id");
        }
    }
}
