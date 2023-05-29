using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DietProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Progresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GoalId1",
                table: "Progresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_GoalId1",
                table: "Progresses",
                column: "GoalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Goals_GoalId1",
                table: "Progresses",
                column: "GoalId1",
                principalTable: "Goals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Goals_GoalId1",
                table: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_Progresses_GoalId1",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "GoalId1",
                table: "Progresses");
        }
    }
}
