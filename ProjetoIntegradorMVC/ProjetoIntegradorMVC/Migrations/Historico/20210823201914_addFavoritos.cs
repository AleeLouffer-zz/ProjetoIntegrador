using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradorMVC.Migrations.Historico
{
    public partial class addFavoritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Cliente_ClienteId1",
                table: "Favoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorDeServico_Favoritos_FavoritosClienteId",
                table: "PrestadorDeServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_ClienteId1",
                table: "Favoritos");

            migrationBuilder.RenameColumn(
                name: "FavoritosClienteId",
                table: "PrestadorDeServico",
                newName: "FavoritosId");

            migrationBuilder.RenameIndex(
                name: "IX_PrestadorDeServico_FavoritosClienteId",
                table: "PrestadorDeServico",
                newName: "IX_PrestadorDeServico_FavoritosId");

            migrationBuilder.RenameColumn(
                name: "ClienteId1",
                table: "Favoritos",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Favoritos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Favoritos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ClienteId",
                table: "Favoritos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Cliente_ClienteId",
                table: "Favoritos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorDeServico_Favoritos_FavoritosId",
                table: "PrestadorDeServico",
                column: "FavoritosId",
                principalTable: "Favoritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Cliente_ClienteId",
                table: "Favoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorDeServico_Favoritos_FavoritosId",
                table: "PrestadorDeServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_ClienteId",
                table: "Favoritos");

            migrationBuilder.RenameColumn(
                name: "FavoritosId",
                table: "PrestadorDeServico",
                newName: "FavoritosClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_PrestadorDeServico_FavoritosId",
                table: "PrestadorDeServico",
                newName: "IX_PrestadorDeServico_FavoritosClienteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Favoritos",
                newName: "ClienteId1");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Favoritos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId1",
                table: "Favoritos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ClienteId1",
                table: "Favoritos",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Cliente_ClienteId1",
                table: "Favoritos",
                column: "ClienteId1",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorDeServico_Favoritos_FavoritosClienteId",
                table: "PrestadorDeServico",
                column: "FavoritosClienteId",
                principalTable: "Favoritos",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
