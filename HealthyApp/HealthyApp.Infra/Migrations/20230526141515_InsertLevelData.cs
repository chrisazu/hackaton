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
                    { 1, "Estoy como Leonardo DiCaprio", "Beginner", 1 },
                    { 2, "Estoy como Emma Stone", "Intermediate", 2 },
                    { 3, "Estoy como Chris Pratt", "Upper Intermediate", 3 },
                    { 4, "Estoy como Scarlett Johansson", "Advanced", 4 },
                    { 5, "Estoy como Dwayne Johnson", "Skilled", 5 },
                    { 6, "Estoy como Angelina Jolie", "Expert", 6 },
                    { 7, "Estoy como Tom Hardy", "Elite", 7 },
                    { 8, "Estoy como Gal Gadot", "Grandmaster", 8 },
                    { 9, "Estoy como Chris Hemsworth", "Masterful", 8 },
                    { 10, "Estoy como Arnold Schwarzenegger", "Champion", 8 }
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

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
