using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAspnetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "HealthyUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "HealthyUsers");
        }
    }
}
