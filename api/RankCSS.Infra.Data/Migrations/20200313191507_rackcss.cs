using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankCSS.Infra.Data.Migrations
{
    public partial class rackcss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Conteudo = table.Column<byte[]>(nullable: false),
                    Processado = table.Column<bool>(nullable: false),
                    DataProcessamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");
        }
    }
}
