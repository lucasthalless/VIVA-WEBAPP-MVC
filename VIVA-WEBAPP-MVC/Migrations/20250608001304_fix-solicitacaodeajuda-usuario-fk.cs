using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VIVA_WEBAPP_MVC.Migrations
{
    /// <inheritdoc />
    public partial class fixsolicitacaodeajudausuariofk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solicitacaoDeAjuda_usuario_UsuarioId",
                table: "solicitacaoDeAjuda");

            migrationBuilder.DropIndex(
                name: "IX_solicitacaoDeAjuda_UsuarioId",
                table: "solicitacaoDeAjuda");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "solicitacaoDeAjuda");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacaoDeAjuda_IdUsuario",
                table: "solicitacaoDeAjuda",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_solicitacaoDeAjuda_usuario_IdUsuario",
                table: "solicitacaoDeAjuda",
                column: "IdUsuario",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solicitacaoDeAjuda_usuario_IdUsuario",
                table: "solicitacaoDeAjuda");

            migrationBuilder.DropIndex(
                name: "IX_solicitacaoDeAjuda_IdUsuario",
                table: "solicitacaoDeAjuda");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "solicitacaoDeAjuda",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_solicitacaoDeAjuda_UsuarioId",
                table: "solicitacaoDeAjuda",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_solicitacaoDeAjuda_usuario_UsuarioId",
                table: "solicitacaoDeAjuda",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "Id");
        }
    }
}
