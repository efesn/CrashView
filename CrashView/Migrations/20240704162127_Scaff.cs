using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashView.Migrations
{
    /// <inheritdoc />
    public partial class Scaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Roles_Role_ID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_Team_ID",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "PersonTeamHistory",
                columns: table => new
                {
                    PersonTeamHistory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Person_ID = table.Column<int>(type: "int", nullable: false),
                    Team_ID = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Person_Id = table.Column<int>(type: "int", nullable: false),
                    Team_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTeamHistory", x => x.PersonTeamHistory_ID);
                    table.ForeignKey(
                        name: "FK_PersonTeamHistory_Persons_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Persons",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTeamHistory_Teams_Team_ID",
                        column: x => x.Team_ID, 
                        principalTable: "Teams",
                        principalColumn: "Team_ID", 
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Season_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Season_ID);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Track_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Track_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number_Of_Laps = table.Column<int>(type: "int", nullable: false),
                    Fastest_Lap_Record = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Track_Length_km = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total_Race_Length_km = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Audience_Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Track_ID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Race_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Season_ID = table.Column<int>(type: "int", nullable: false),
                    Track_ID = table.Column<int>(type: "int", nullable: false),
                    Race_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Season_ID1 = table.Column<int>(type: "int", nullable: false),
                    Track_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Race_ID);
                    table.ForeignKey(
                        name: "FK_Races_Seasons_Season_ID1",
                        column: x => x.Season_ID1,
                        principalTable: "Seasons",
                        principalColumn: "Season_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Races_Track_Track_ID1",
                        column: x => x.Track_ID1,
                        principalTable: "Track",
                        principalColumn: "Track_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crashes",
                columns: table => new
                {
                    Crash_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race_ID = table.Column<int>(type: "int", nullable: false),
                    Person_ID = table.Column<int>(type: "int", nullable: false),
                    CrashDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrashDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Race_ID1 = table.Column<int>(type: "int", nullable: false),
                    Person_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crashes", x => x.Crash_ID);
                    table.ForeignKey(
                        name: "FK_Crashes_Persons_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Persons",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crashes_Races_Race_ID1",
                        column: x => x.Race_ID1,
                        principalTable: "Races",
                        principalColumn: "Race_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    RaceResult_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race_ID = table.Column<int>(type: "int", nullable: false),
                    Race_ID1 = table.Column<int>(type: "int", nullable: false),
                    Person_ID = table.Column<int>(type: "int", nullable: false),
                    Person_Id = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.RaceResult_ID);
                    table.ForeignKey(
                        name: "FK_RaceResults_Persons_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Persons",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceResults_Races_Race_ID1",
                        column: x => x.Race_ID1,
                        principalTable: "Races",
                        principalColumn: "Race_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crashes_Person_Id",
                table: "Crashes",
                column: "Person_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Crashes_Race_ID1",
                table: "Crashes",
                column: "Race_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeamHistory_Person_Id",
                table: "PersonTeamHistory",
                column: "Person_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeamHistory_Team_ID1",
                table: "PersonTeamHistory",
                column: "Team_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_Person_Id",
                table: "RaceResults",
                column: "Person_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_Race_ID1",
                table: "RaceResults",
                column: "Race_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Races_Season_ID1",
                table: "Races",
                column: "Season_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Races_Track_ID1",
                table: "Races",
                column: "Track_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Roles_Role_ID",
                table: "Persons",
                column: "Role_ID",
                principalTable: "Roles",
                principalColumn: "Role_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_Team_ID",
                table: "Persons",
                column: "Team_ID",
                principalTable: "Teams",
                principalColumn: "Team_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Roles_Role_ID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_Team_ID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Crashes");

            migrationBuilder.DropTable(
                name: "PersonTeamHistory");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Roles_Role_ID",
                table: "Persons",
                column: "Role_ID",
                principalTable: "Roles",
                principalColumn: "Role_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_Team_ID",
                table: "Persons",
                column: "Team_ID",
                principalTable: "Teams",
                principalColumn: "Team_ID");
        }
    }
}
