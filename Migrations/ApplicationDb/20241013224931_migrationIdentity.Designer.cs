﻿// <auto-generated />
using System;
using CareWithLoveApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareWithLoveApp.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013224931_migrationIdentity")]
    partial class migrationIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
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

                    b.Property<string>("UsuarioId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Avaliacao", "Identity");
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

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CuidadorId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("Cuidador", "Identity");
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

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DependenteId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Dependente", "Identity");
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

                    b.ToTable("ServicoCliente", "Identity");
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

                    b.ToTable("ServicoCuidador", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "Identity");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("UsuarioLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioSexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioTipo")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("User", "Identity");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Avaliacao", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.User", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Cuidador", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.User", "Usuario")
                        .WithOne("Cuidador")
                        .HasForeignKey("CareWithLoveApp.Models.Entities.Cuidador", "UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Dependente", b =>
                {
                    b.HasOne("CareWithLoveApp.Models.Entities.User", "Usuario")
                        .WithMany("Dependentes")
                        .HasForeignKey("UsuarioId1");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.User", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("CareWithLoveApp.Models.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Cuidador", b =>
                {
                    b.Navigation("ServicosCuidador");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.Dependente", b =>
                {
                    b.Navigation("ServicosClientes");
                });

            modelBuilder.Entity("CareWithLoveApp.Models.Entities.User", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Cuidador");

                    b.Navigation("Dependentes");
                });
#pragma warning restore 612, 618
        }
    }
}