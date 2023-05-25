using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InsertLevelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Beginner", "Beginner", 1 },
                    { 2, "Intermediate", "Intermediate", 2 },
                    { 3, "Upper Intermediate", "Upper Intermediate", 3 },
                    { 4, "Advanced", "Advanced", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
