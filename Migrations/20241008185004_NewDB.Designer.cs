﻿// <auto-generated />
using System;
using CareWithLoveApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareWithLoveApp.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20241008185004_NewDB")]
    partial class NewDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Avaliacao", b =>
                {
                    b.Property<Guid>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbAvaliacao", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Cuidador", b =>
                {
                    b.Property<Guid>("CuidadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disponibilidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especializacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experiencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CuidadorId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("tbCuidador", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Dependente", b =>
                {
                    b.Property<Guid>("DependenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cuidados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DependenteEndereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DependenteIdade")
                        .HasColumnType("int");

                    b.Property<string>("DependenteNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Insulina")
                        .HasColumnType("bit");

                    b.Property<string>("TelefoneEmergencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DependenteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbDependente", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.ServicoCliente", b =>
                {
                    b.Property<Guid>("ServicoClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DependenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicoClienteId");

                    b.HasIndex("DependenteId");

                    b.ToTable("tbServicoClientes", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.ServicoCuidador", b =>
                {
                    b.Property<Guid>("ServicoCuidadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CuidadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preferencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicoCuidadorId");

                    b.HasIndex("CuidadorId");

                    b.ToTable("tbServicoCuidador", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("UsuarioEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioSenha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioSexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("tbUsuario", (string)null);
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Avaliacao", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.Usuario", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Cuidador", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.Usuario", "Usuario")
                        .WithOne("Cuidador")
                        .HasForeignKey("CareWithLoveApp.Models.Entities.Cuidador", "UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Dependente", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.Usuario", "Usuario")
                        .WithMany("Dependentes")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.ServicoCliente", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.Dependente", "Dependente")
                        .WithMany("ServicosClientes")
                        .HasForeignKey("DependenteId");

                    b.Navigation("Dependente");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.ServicoCuidador", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.Cuidador", "Cuidador")
                        .WithMany("ServicosCuidador")
                        .HasForeignKey("CuidadorId");

                    b.Navigation("Cuidador");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Cuidador", b =>
                {
                    b.Navigation("ServicosCuidador");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Dependente", b =>
                {
                    b.Navigation("ServicosClientes");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Usuario", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Cuidador");

                    b.Navigation("Dependentes");
                });
#pragma warning restore 612, 618
        }
    }
}