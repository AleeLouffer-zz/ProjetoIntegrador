using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempoEstimado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
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
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JornadaDeTrabalhoId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_JornadaDeTrabalho_JornadaDeTrabalhoId",
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

            migrationBuilder.CreateTable(
                name: "FuncionariosComServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosComServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionariosComServicos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosComServicos_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaDeTrabalho_JornadaDeTrabalhoId",
                table: "DiaDeTrabalho",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CPF",
                table: "Funcionarios",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_JornadaDeTrabalhoId",
                table: "Funcionarios",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosComServicos_FuncionarioId",
                table: "FuncionariosComServicos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosComServicos_ServicoId",
                table: "FuncionariosComServicos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeTrabalho_JornadaDeTrabalhoId",
                table: "HorarioDeTrabalho",
                column: "JornadaDeTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Nome",
                table: "Servico",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Preco",
                table: "Servico",
                column: "Preco",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaDeTrabalho");

            migrationBuilder.DropTable(
                name: "FuncionariosComServicos");

            migrationBuilder.DropTable(
                name: "HorarioDeTrabalho");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "JornadaDeTrabalho");
        }
    }
}
