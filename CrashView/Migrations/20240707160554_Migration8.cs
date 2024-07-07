using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crashes_Races_Race_ID1",
                table: "Crashes");

            migrationBuilder.DropIndex(
                name: "IX_Crashes_Race_ID1",
                table: "Crashes");

            migrationBuilder.DropColumn(
                name: "Race_ID1",
                table: "Crashes");

            migrationBuilder.CreateIndex(
                name: "IX_Crashes_Race_ID",
                table: "Crashes",
                column: "Race_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crashes_Races_Race_ID",
                table: "Crashes",
                column: "Race_ID",
                principalTable: "Races",
                principalColumn: "Race_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crashes_Races_Race_ID",
                table: "Crashes");

            migrationBuilder.DropIndex(
                name: "IX_Crashes_Race_ID",
                table: "Crashes");

            migrationBuilder.AddColumn<int>(
                name: "Race_ID1",
                table: "Crashes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Crashes_Race_ID1",
                table: "Crashes",
                column: "Race_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Crashes_Races_Race_ID1",
                table: "Crashes",
                column: "Race_ID1",
                principalTable: "Races",
                principalColumn: "Race_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
