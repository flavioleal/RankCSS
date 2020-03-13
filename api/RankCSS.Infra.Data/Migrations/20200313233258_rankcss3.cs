using Microsoft.EntityFrameworkCore.Migrations;

namespace RankCSS.Infra.Data.Migrations
{
    public partial class rankcss3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "PlantedBomb",
                table: "Round",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "DefusedBomb",
                table: "Round",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Processed",
                table: "File",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PlantedBomb",
                table: "Round",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DefusedBomb",
                table: "Round",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Processed",
                table: "File",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");
        }
    }
}
