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
            migrationBuilder.DropForeignKey(
                name: "FK_tbCuidador_tbUsuario_UsuarioId",
                table: "tbCuidador");

            migrationBuilder.AddColumn<Guid>(
                name: "CuidadorId",
                table: "tbUsuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "tbDependente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "tbCuidador",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "tbAvaliacao",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbUsuario_CuidadorId",
                table: "tbUsuario",
                column: "CuidadorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbDependente_UsuarioId1",
                table: "tbDependente",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacao_UsuarioId1",
                table: "tbAvaliacao",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAvaliacao_Usuarios_UsuarioId1",
                table: "tbAvaliacao",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCuidador_Usuarios_UsuarioId",
                table: "tbCuidador",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbDependente_Usuarios_UsuarioId1",
                table: "tbDependente",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbUsuario_tbCuidador_CuidadorId",
                table: "tbUsuario",
                column: "CuidadorId",
                principalTable: "tbCuidador",
                principalColumn: "CuidadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAvaliacao_Usuarios_UsuarioId1",
                table: "tbAvaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_tbCuidador_Usuarios_UsuarioId",
                table: "tbCuidador");

            migrationBuilder.DropForeignKey(
                name: "FK_tbDependente_Usuarios_UsuarioId1",
                table: "tbDependente");

            migrationBuilder.DropForeignKey(
                name: "FK_tbUsuario_tbCuidador_CuidadorId",
                table: "tbUsuario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_tbUsuario_CuidadorId",
                table: "tbUsuario");

            migrationBuilder.DropIndex(
                name: "IX_tbDependente_UsuarioId1",
                table: "tbDependente");

            migrationBuilder.DropIndex(
                name: "IX_tbAvaliacao_UsuarioId1",
                table: "tbAvaliacao");

            migrationBuilder.DropColumn(
                name: "CuidadorId",
                table: "tbUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "tbDependente");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "tbAvaliacao");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "tbCuidador",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbCuidador_tbUsuario_UsuarioId",
                table: "tbCuidador",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "UsuarioId");
        }
    }
}
