﻿// <auto-generated />
using System;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alura.LeilaoOnline.Dados.Migrations
{
    [DbContext(typeof(LeiloesContext))]
    [Migration("20240627170636_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Favorito", b =>
                {
                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<int>("IdInteressada")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("LeilaoId", "IdInteressada");

                    b.HasIndex("IdInteressada");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Interessada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interessada");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fulano de Tal"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Mariana Mary"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Sicrana Silva"
                        });
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Lance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Lance");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Leilao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GanhadorId")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InicioPregao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TerminoPregao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorInicial")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GanhadorId");

                    b.ToTable("Leiloes");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InteressadaId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InteressadaId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "fulano@example.org",
                            InteressadaId = 1,
                            Senha = "123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mariana@example.org",
                            InteressadaId = 2,
                            Senha = "456"
                        },
                        new
                        {
                            Id = 3,
                            Email = "admin@example.org",
                            Senha = "123"
                        });
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Favorito", b =>
                {
                    b.HasOne("Alura.LeilaoOnline.Core.Interessada", "Seguidor")
                        .WithMany("Favoritos")
                        .HasForeignKey("IdInteressada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.LeilaoOnline.Core.Leilao", "LeilaoFavorito")
                        .WithMany("Seguidores")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeilaoFavorito");

                    b.Navigation("Seguidor");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Lance", b =>
                {
                    b.HasOne("Alura.LeilaoOnline.Core.Interessada", "Cliente")
                        .WithMany("Lances")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.LeilaoOnline.Core.Leilao", "Leilao")
                        .WithMany("Lances")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Leilao");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Leilao", b =>
                {
                    b.HasOne("Alura.LeilaoOnline.Core.Lance", "Ganhador")
                        .WithMany()
                        .HasForeignKey("GanhadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganhador");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Usuario", b =>
                {
                    b.HasOne("Alura.LeilaoOnline.Core.Interessada", "Interessada")
                        .WithMany()
                        .HasForeignKey("InteressadaId");

                    b.Navigation("Interessada");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Interessada", b =>
                {
                    b.Navigation("Favoritos");

                    b.Navigation("Lances");
                });

            modelBuilder.Entity("Alura.LeilaoOnline.Core.Leilao", b =>
                {
                    b.Navigation("Lances");

                    b.Navigation("Seguidores");
                });
#pragma warning restore 612, 618
        }
    }
}
