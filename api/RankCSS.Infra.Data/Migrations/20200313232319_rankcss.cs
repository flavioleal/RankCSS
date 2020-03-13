using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankCSS.Infra.Data.Migrations
{
    public partial class rankcss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Rodada");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<byte[]>(type: "blob", nullable: false),
                    Processed = table.Column<bool>(nullable: false),
                    ProcessingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Map = table.Column<string>(maxLength: 100, nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nickname = table.Column<string>(maxLength: 100, nullable: false),
                    IP = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(nullable: false),
                    RoundID = table.Column<Guid>(nullable: false),
                    Kill = table.Column<int>(nullable: false),
                    Death = table.Column<int>(nullable: false),
                    FriendlyFire = table.Column<int>(nullable: true),
                    HS = table.Column<int>(nullable: true),
                    PlantedBomb = table.Column<bool>(nullable: true),
                    DefusedBomb = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => new { x.PlayerID, x.RoundID });
                    table.ForeignKey(
                        name: "FK_Round_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_Match_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Match",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Round_RoundID",
                table: "Round",
                column: "RoundID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Conteudo = table.Column<byte[]>(type: "blob", nullable: false),
                    DataProcessamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    Processado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    IP = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Mapa = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rodada",
                columns: table => new
                {
                    JogadorID = table.Column<Guid>(type: "char(36)", nullable: false),
                    PartidaID = table.Column<Guid>(type: "char(36)", nullable: false),
                    BombasDefusadas = table.Column<int>(type: "int", nullable: true),
                    BombasPlantadas = table.Column<int>(type: "int", nullable: true),
                    FogoAmigo = table.Column<int>(type: "int", nullable: true),
                    Matou = table.Column<int>(type: "int", nullable: false),
                    Morreu = table.Column<int>(type: "int", nullable: false),
                    TiroCabeca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodada", x => new { x.JogadorID, x.PartidaID });
                    table.ForeignKey(
                        name: "FK_Rodada_Jogador_JogadorID",
                        column: x => x.JogadorID,
                        principalTable: "Jogador",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rodada_Partida_PartidaID",
                        column: x => x.PartidaID,
                        principalTable: "Partida",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rodada_PartidaID",
                table: "Rodada",
                column: "PartidaID");
        }
    }
}
