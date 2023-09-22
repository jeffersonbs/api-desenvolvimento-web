using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Data.Migrations
{
    public partial class Diagnosticoempaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiagnosticoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DiagnosticoId",
                table: "Pacientes",
                column: "DiagnosticoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Diagnosticos_DiagnosticoId",
                table: "Pacientes",
                column: "DiagnosticoId",
                principalTable: "Diagnosticos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Diagnosticos_DiagnosticoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_DiagnosticoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DiagnosticoId",
                table: "Pacientes");
        }
    }
}
