using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionariosComServicosId",
                table: "Servico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionariosComServicosId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FuncionariosComServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosComServicos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servico_FuncionariosComServicosId",
                table: "Servico",
                column: "FuncionariosComServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FuncionariosComServicosId",
                table: "Funcionarios",
                column: "FuncionariosComServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_FuncionariosComServicos_FuncionariosComServicosId",
                table: "Funcionarios",
                column: "FuncionariosComServicosId",
                principalTable: "FuncionariosComServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_FuncionariosComServicos_FuncionariosComServicosId",
                table: "Servico",
                column: "FuncionariosComServicosId",
                principalTable: "FuncionariosComServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_FuncionariosComServicos_FuncionariosComServicosId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_FuncionariosComServicos_FuncionariosComServicosId",
                table: "Servico");

            migrationBuilder.DropTable(
                name: "FuncionariosComServicos");

            migrationBuilder.DropIndex(
                name: "IX_Servico_FuncionariosComServicosId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_FuncionariosComServicosId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FuncionariosComServicosId",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "FuncionariosComServicosId",
                table: "Funcionarios");
        }
    }
}
