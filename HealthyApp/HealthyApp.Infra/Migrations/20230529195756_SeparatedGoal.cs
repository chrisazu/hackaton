using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeparatedGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_DietGoalId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_ExercisesGoalId",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Kilograms",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "TimesPerFrequency",
                table: "Goals");

            migrationBuilder.CreateTable(
                name: "DietGoals",
                columns: table => new
                {
                    DietGoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    Kilograms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietGoals", x => x.DietGoalId);
                    table.ForeignKey(
                        name: "FK_DietGoals_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseGoals",
                columns: table => new
                {
                    ExercisesGoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    TimesPerFrequency = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseGoals", x => x.ExercisesGoalId);
                    table.ForeignKey(
                        name: "FK_ExerciseGoals_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietGoals_GoalId",
                table: "DietGoals",
                column: "GoalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseGoals_GoalId",
                table: "ExerciseGoals",
                column: "GoalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_DietGoals_DietGoalId",
                table: "Progresses",
                column: "DietGoalId",
                principalTable: "DietGoals",
                principalColumn: "DietGoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_ExerciseGoals_ExercisesGoalId",
                table: "Progresses",
                column: "ExercisesGoalId",
                principalTable: "ExerciseGoals",
                principalColumn: "ExercisesGoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_DietGoals_DietGoalId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_ExerciseGoals_ExercisesGoalId",
                table: "Progresses");

            migrationBuilder.DropTable(
                name: "DietGoals");

            migrationBuilder.DropTable(
                name: "ExerciseGoals");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Goals",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Goals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kilograms",
                table: "Goals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimesPerFrequency",
                table: "Goals",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goals_DietGoalId",
                table: "Progresses",
                column: "DietGoalId",
                principalTable: "Goals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goals_ExercisesGoalId",
                table: "Progresses",
                column: "ExercisesGoalId",
                principalTable: "Goals",
                principalColumn: "Id");
        }
    }
}
