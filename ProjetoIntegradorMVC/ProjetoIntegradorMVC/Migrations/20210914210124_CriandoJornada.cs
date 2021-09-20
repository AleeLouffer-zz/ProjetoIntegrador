using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations
{
    public partial class CriandoJornada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TempoEstimado",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JornadaDeTrabalhoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JornadaDeTrabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JornadaDeTrabalho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaDeTrabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JornadaDeTrabalhoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDeTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaDeTrabalho_JornadaDeTrabalho_JornadaDeTrabalhoId",
                        column: x => x.JornadaDeTrabalhoId,
                        principalTable: "JornadaDeTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDeTrabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JornadaDeTrabalhoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDeTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioDeTrabalho_JornadaDeTrabalho_JornadaDeTrabalhoId",
                        column: x => x.JornadaDeTrabalhoId,
                        principalTable: "JornadaDeTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_JornadaDeTrabalhoId",
                table: "Funcionarios",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDeTrabalho_JornadaDeTrabalhoId",
                table: "DiaDeTrabalho",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeTrabalho_JornadaDeTrabalhoId",
                table: "HorarioDeTrabalho",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_JornadaDeTrabalho_JornadaDeTrabalhoId",
                table: "Funcionarios",
                column: "JornadaDeTrabalhoId",
                principalTable: "JornadaDeTrabalho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_JornadaDeTrabalho_JornadaDeTrabalhoId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "DiaDeTrabalho");

            migrationBuilder.DropTable(
                name: "HorarioDeTrabalho");

            migrationBuilder.DropTable(
                name: "JornadaDeTrabalho");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_JornadaDeTrabalhoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TempoEstimado",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "JornadaDeTrabalhoId",
                table: "Funcionarios");
        }
    }
}
