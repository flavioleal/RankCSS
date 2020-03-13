using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankCSS.Infra.Data.Migrations
{
    public partial class ranckcss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Conteudo",
                table: "Arquivo",
                type: "blob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Conteudo",
                table: "Arquivo",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "blob");
        }
    }
}
