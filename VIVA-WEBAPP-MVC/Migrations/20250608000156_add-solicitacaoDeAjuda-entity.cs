using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VIVA_WEBAPP_MVC.Migrations
{
    /// <inheritdoc />
    public partial class addsolicitacaoDeAjudaentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "solicitacaoDeAjuda",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoSolicitacao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: true),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Nivel = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitacaoDeAjuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solicitacaoDeAjuda_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_solicitacaoDeAjuda_UsuarioId",
                table: "solicitacaoDeAjuda",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "solicitacaoDeAjuda");
        }
    }
}
