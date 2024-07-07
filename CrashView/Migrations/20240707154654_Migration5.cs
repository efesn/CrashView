using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Seasons_Season_ID1",
                table: "Races");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.AlterColumn<string>(
                name: "Fastest_Lap_Record",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Season_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Season_Season_ID1",
                table: "Races",
                column: "Season_ID1",
                principalTable: "Season",
                principalColumn: "Season_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Season_Season_ID1",
                table: "Races");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fastest_Lap_Record",
                table: "Track",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "Season_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Seasons_Season_ID1",
                table: "Races",
                column: "Season_ID1",
                principalTable: "Seasons",
                principalColumn: "Season_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
