using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Goal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_UserId",
                table: "Goals",
                newName: "IX_Goals_UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_HealthyUsers_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_DietGoalId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_ExercisesGoalId",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_UserId",
                table: "Goal",
                newName: "IX_Goal_UserId");

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
    }
}
