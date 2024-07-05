using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class ScaffSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTeamHistory_Persons_Person_Id",
                table: "PersonTeamHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonTeamHistory_Teams_Team_ID1",
                table: "PersonTeamHistory");

            migrationBuilder.DropIndex(
                name: "IX_PersonTeamHistory_Team_ID1",
                table: "PersonTeamHistory");

            migrationBuilder.DropColumn(
                name: "Person_ID",
                table: "PersonTeamHistory");

            migrationBuilder.DropColumn(
                name: "Team_ID1",
                table: "PersonTeamHistory");

            migrationBuilder.RenameColumn(
                name: "Person_Id",
                table: "PersonTeamHistory",
                newName: "Person_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTeamHistory_Person_Id",
                table: "PersonTeamHistory",
                newName: "IX_PersonTeamHistory_Person_ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "PersonTeamHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeamHistory_Team_ID",
                table: "PersonTeamHistory",
                column: "Team_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTeamHistory_Persons_Person_ID",
                table: "PersonTeamHistory",
                column: "Person_ID",
                principalTable: "Persons",
                principalColumn: "Person_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTeamHistory_Teams_Team_ID",
                table: "PersonTeamHistory",
                column: "Team_ID",
                principalTable: "Teams",
                principalColumn: "Team_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTeamHistory_Persons_Person_ID",
                table: "PersonTeamHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonTeamHistory_Teams_Team_ID",
                table: "PersonTeamHistory");

            migrationBuilder.DropIndex(
                name: "IX_PersonTeamHistory_Team_ID",
                table: "PersonTeamHistory");

            migrationBuilder.RenameColumn(
                name: "Person_ID",
                table: "PersonTeamHistory",
                newName: "Person_Id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTeamHistory_Person_ID",
                table: "PersonTeamHistory",
                newName: "IX_PersonTeamHistory_Person_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "PersonTeamHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Person_ID",
                table: "PersonTeamHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team_ID1",
                table: "PersonTeamHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeamHistory_Team_ID1",
                table: "PersonTeamHistory",
                column: "Team_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTeamHistory_Persons_Person_Id",
                table: "PersonTeamHistory",
                column: "Person_Id",
                principalTable: "Persons",
                principalColumn: "Person_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTeamHistory_Teams_Team_ID1",
                table: "PersonTeamHistory",
                column: "Team_ID1",
                principalTable: "Teams",
                principalColumn: "Team_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
