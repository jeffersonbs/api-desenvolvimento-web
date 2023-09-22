using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Data.Migrations
{
    public partial class CorrecaoDiagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Diagnosticos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_PacienteId",
                table: "Diagnosticos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Pacientes_PacienteId",
                table: "Diagnosticos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Pacientes_PacienteId",
                table: "Diagnosticos");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosticos_PacienteId",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Diagnosticos");

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
    }
}
