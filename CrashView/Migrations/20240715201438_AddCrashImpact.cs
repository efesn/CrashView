using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class AddCrashImpact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Impact",
                table: "Crashes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Impact",
                table: "Crashes");
        }
    }
}
