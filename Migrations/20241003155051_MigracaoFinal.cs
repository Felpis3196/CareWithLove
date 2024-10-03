using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareWithLoveApp.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAvaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAvaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_tbAvaliacao_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacao_UsuarioId",
                table: "tbAvaliacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAvaliacao");
        }
    }
}
