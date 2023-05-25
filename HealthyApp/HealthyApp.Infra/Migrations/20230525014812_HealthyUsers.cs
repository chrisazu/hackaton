using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class HealthyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_HealthyUser_UserId",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthyUser",
                table: "HealthyUser");

            migrationBuilder.RenameTable(
                name: "HealthyUser",
                newName: "HealthyUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthyUsers",
                table: "HealthyUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_HealthyUsers_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "HealthyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_HealthyUsers_UserId",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthyUsers",
                table: "HealthyUsers");

            migrationBuilder.RenameTable(
                name: "HealthyUsers",
                newName: "HealthyUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthyUser",
                table: "HealthyUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_HealthyUser_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "HealthyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
