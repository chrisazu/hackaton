using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class KilogramsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kilograms",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilograms",
                table: "Goals");
        }
    }
}
