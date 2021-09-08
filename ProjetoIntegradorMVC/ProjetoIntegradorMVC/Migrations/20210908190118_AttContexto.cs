using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations
{
    public partial class AttContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Funcionarios");
        }
    }
}
