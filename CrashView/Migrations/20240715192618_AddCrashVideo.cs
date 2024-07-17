using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class AddCrashVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Persons_Person_Id",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Races_Race_ID1",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Season_Season_ID1",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Track_Track_ID1",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_Season_ID1",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_Track_ID1",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_Person_Id",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_Race_ID1",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Season_ID1",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Track_ID1",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Person_ID",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Race_ID1",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "Person_Id",
                table: "RaceResults",
                newName: "Person_ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "PersonTeamHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<byte[]>(
                name: "Crash_Video",
                table: "Crashes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Races_Season_ID",
                table: "Races",
                column: "Season_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Races_Track_ID",
                table: "Races",
                column: "Track_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Season_Season_ID",
                table: "Races",
                column: "Season_ID",
                principalTable: "Season",
                principalColumn: "Season_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Track_Track_ID",
                table: "Races",
                column: "Track_ID",
                principalTable: "Track",
                principalColumn: "Track_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Season_Season_ID",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Track_Track_ID",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_Season_ID",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_Track_ID",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Crash_Video",
                table: "Crashes");

            migrationBuilder.RenameColumn(
                name: "Person_ID",
                table: "RaceResults",
                newName: "Person_Id");

            migrationBuilder.AddColumn<int>(
                name: "Season_ID1",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Track_ID1",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Person_ID",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Race_ID1",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "PersonTeamHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_Season_ID1",
                table: "Races",
                column: "Season_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Races_Track_ID1",
                table: "Races",
                column: "Track_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_Person_Id",
                table: "RaceResults",
                column: "Person_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_Race_ID1",
                table: "RaceResults",
                column: "Race_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Persons_Person_Id",
                table: "RaceResults",
                column: "Person_Id",
                principalTable: "Persons",
                principalColumn: "Person_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Races_Race_ID1",
                table: "RaceResults",
                column: "Race_ID1",
                principalTable: "Races",
                principalColumn: "Race_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Season_Season_ID1",
                table: "Races",
                column: "Season_ID1",
                principalTable: "Season",
                principalColumn: "Season_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Track_Track_ID1",
                table: "Races",
                column: "Track_ID1",
                principalTable: "Track",
                principalColumn: "Track_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
