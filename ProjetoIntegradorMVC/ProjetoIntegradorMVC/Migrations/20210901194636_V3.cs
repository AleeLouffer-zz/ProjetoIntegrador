using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "FuncionariosComServicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdServico",
                table: "FuncionariosComServicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "FuncionariosComServicos");

            migrationBuilder.DropColumn(
                name: "IdServico",
                table: "FuncionariosComServicos");
        }
    }
}
