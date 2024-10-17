using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareWithLoveApp.Migrations
{
    /// <inheritdoc />
    public partial class modelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioSexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    UsuarioLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuidador",
                columns: table => new
                {
                    CuidadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Disponibilidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especializacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidador", x => x.CuidadorId);
                    table.ForeignKey(
                        name: "FK_Cuidador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    DependenteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DependenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependenteIdade = table.Column<int>(type: "int", nullable: true),
                    DependenteEndereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insulina = table.Column<bool>(type: "bit", nullable: true),
                    TelefoneEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuidados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.DependenteId);
                    table.ForeignKey(
                        name: "FK_Dependente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServicoCuidador",
                columns: table => new
                {
                    ServicoCuidadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preferencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuidadorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCuidador", x => x.ServicoCuidadorId);
                    table.ForeignKey(
                        name: "FK_ServicoCuidador_Cuidador_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "Cuidador",
                        principalColumn: "CuidadorId");
                });

            migrationBuilder.CreateTable(
                name: "ServicoClientes",
                columns: table => new
                {
                    ServicoClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependenteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoClientes", x => x.ServicoClienteId);
                    table.ForeignKey(
                        name: "FK_ServicoClientes_Dependente_DependenteId",
                        column: x => x.DependenteId,
                        principalTable: "Dependente",
                        principalColumn: "DependenteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_UsuarioId",
                table: "Avaliacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuidador_UsuarioId",
                table: "Cuidador",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_UsuarioId",
                table: "Dependente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoClientes_DependenteId",
                table: "ServicoClientes",
                column: "DependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoCuidador_CuidadorId",
                table: "ServicoCuidador",
                column: "CuidadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "ServicoClientes");

            migrationBuilder.DropTable(
                name: "ServicoCuidador");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Cuidador");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
