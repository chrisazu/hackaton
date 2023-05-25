using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardStatus",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "GoalStatus",
                table: "Goals",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Rewards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "HealthyUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Goals",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesPerFrequency",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "GoalProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<TimeSpan>(type: "time", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalProgresses_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_LevelId",
                table: "Rewards",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthyUsers_LevelId",
                table: "HealthyUsers",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalProgresses_GoalId",
                table: "GoalProgresses",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthyUsers_Levels_LevelId",
                table: "HealthyUsers",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Levels_LevelId",
                table: "Rewards",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthyUsers_Levels_LevelId",
                table: "HealthyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Levels_LevelId",
                table: "Rewards");

            migrationBuilder.DropTable(
                name: "GoalProgresses");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_LevelId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_HealthyUsers_LevelId",
                table: "HealthyUsers");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "HealthyUsers");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "TimesPerFrequency",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Goals",
                newName: "GoalStatus");

            migrationBuilder.AddColumn<int>(
                name: "RewardStatus",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
