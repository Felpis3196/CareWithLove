using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareWithLoveApp.Migrations
{
    /// <inheritdoc />
    public partial class Migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioSexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    UsuarioLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioTipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "tbCuidador",
                columns: table => new
                {
                    CuidadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Disponibilidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especializacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCuidador", x => x.CuidadorId);
                    table.ForeignKey(
                        name: "FK_tbCuidador_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "tbDependente",
                columns: table => new
                {
                    DependenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependenteIdade = table.Column<int>(type: "int", nullable: true),
                    DependenteEndereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insulina = table.Column<bool>(type: "bit", nullable: true),
                    TelefoneEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuidados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDependente", x => x.DependenteId);
                    table.ForeignKey(
                        name: "FK_tbDependente_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "tbServicoCuidador",
                columns: table => new
                {
                    ServicoCuidadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preferencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuidadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbServicoCuidador", x => x.ServicoCuidadorId);
                    table.ForeignKey(
                        name: "FK_tbServicoCuidador_tbCuidador_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "tbCuidador",
                        principalColumn: "CuidadorId");
                });

            migrationBuilder.CreateTable(
                name: "tbServicoClientes",
                columns: table => new
                {
                    ServicoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbServicoClientes", x => x.ServicoClienteId);
                    table.ForeignKey(
                        name: "FK_tbServicoClientes_tbDependente_DependenteId",
                        column: x => x.DependenteId,
                        principalTable: "tbDependente",
                        principalColumn: "DependenteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCuidador_UsuarioId",
                table: "tbCuidador",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbDependente_UsuarioId",
                table: "tbDependente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbServicoClientes_DependenteId",
                table: "tbServicoClientes",
                column: "DependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbServicoCuidador_CuidadorId",
                table: "tbServicoCuidador",
                column: "CuidadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbServicoClientes");

            migrationBuilder.DropTable(
                name: "tbServicoCuidador");

            migrationBuilder.DropTable(
                name: "tbDependente");

            migrationBuilder.DropTable(
                name: "tbCuidador");

            migrationBuilder.DropTable(
                name: "tbUsuario");
        }
    }
}
