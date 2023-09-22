using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Data.Migrations
{
    public partial class AdicaoNomeCid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeDoenca",
                table: "CIDs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoenca",
                table: "CIDs");
        }
    }
}
