using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankCSS.Infra.Data.Migrations
{
    public partial class rankflavio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    IP = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Mapa = table.Column<string>(maxLength: 100, nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rodada",
                columns: table => new
                {
                    JogadorID = table.Column<Guid>(nullable: false),
                    PartidaID = table.Column<Guid>(nullable: false),
                    Matou = table.Column<int>(nullable: false),
                    Morreu = table.Column<int>(nullable: false),
                    FogoAmigo = table.Column<int>(nullable: false),
                    TiroCabeca = table.Column<int>(nullable: false),
                    BombasPlantadas = table.Column<int>(nullable: false),
                    BombasDefusadas = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rodada");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Partida");
        }
    }
}
