using Microsoft.EntityFrameworkCore.Migrations;

namespace cybersport.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre_name = table.Column<string>(nullable: false),
                    Genre_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "NameOfGames",
                columns: table => new
                {
                    NameOfGameID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_of_Game = table.Column<string>(nullable: false),
                    Game_description = table.Column<string>(nullable: false),
                    GenreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameOfGames", x => x.NameOfGameID);
                    table.ForeignKey(
                        name: "FK_NameOfGames_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leag_name = table.Column<string>(nullable: false),
                    Leag_team_num = table.Column<int>(nullable: false),
                    Leag_Type = table.Column<string>(nullable: false),
                    prize_pool = table.Column<int>(nullable: false),
                    NameOfGameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueID);
                    table.ForeignKey(
                        name: "FK_Leagues_NameOfGames_NameOfGameID",
                        column: x => x.NameOfGameID,
                        principalTable: "NameOfGames",
                        principalColumn: "NameOfGameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Team_name = table.Column<string>(nullable: false),
                    LeagueID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "Leagues",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Game_result = table.Column<string>(nullable: true),
                    NameOfGameID = table.Column<int>(nullable: false),
                    Team1ID = table.Column<int>(nullable: false),
                    Team2ID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_NameOfGames_NameOfGameID",
                        column: x => x.NameOfGameID,
                        principalTable: "NameOfGames",
                        principalColumn: "NameOfGameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Teams_Team1ID",
                        column: x => x.Team1ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Teams_Team2ID",
                        column: x => x.Team2ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Manager_name = table.Column<string>(nullable: false),
                    Manager_surname = table.Column<string>(nullable: false),
                    Manager_email = table.Column<string>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_Managers_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Player_name = table.Column<string>(nullable: false),
                    Player_nickname = table.Column<string>(nullable: false),
                    Player_surname = table.Column<string>(nullable: false),
                    Player_email = table.Column<string>(nullable: false),
                    Player_rate = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayingGames",
                columns: table => new
                {
                    PlayingGameID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfGameID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayingGames", x => x.PlayingGameID);
                    table.ForeignKey(
                        name: "FK_PlayingGames_NameOfGames_NameOfGameID",
                        column: x => x.NameOfGameID,
                        principalTable: "NameOfGames",
                        principalColumn: "NameOfGameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayingGames_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreID",
                table: "Games",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_NameOfGameID",
                table: "Games",
                column: "NameOfGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Team1ID",
                table: "Games",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Team2ID",
                table: "Games",
                column: "Team2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_NameOfGameID",
                table: "Leagues",
                column: "NameOfGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_TeamID",
                table: "Managers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_NameOfGames_GenreID",
                table: "NameOfGames",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayingGames_NameOfGameID",
                table: "PlayingGames",
                column: "NameOfGameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayingGames_TeamID",
                table: "PlayingGames",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueID",
                table: "Teams",
                column: "LeagueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayingGames");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "NameOfGames");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
