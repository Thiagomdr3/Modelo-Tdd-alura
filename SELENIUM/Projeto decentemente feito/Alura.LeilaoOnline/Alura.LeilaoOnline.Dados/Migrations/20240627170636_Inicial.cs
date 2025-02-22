﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alura.LeilaoOnline.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interessada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interessada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteressadaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Interessada_InteressadaId",
                        column: x => x.InteressadaId,
                        principalTable: "Interessada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdInteressada = table.Column<int>(type: "int", nullable: false),
                    LeilaoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => new { x.LeilaoId, x.IdInteressada });
                    table.ForeignKey(
                        name: "FK_Favoritos_Interessada_IdInteressada",
                        column: x => x.IdInteressada,
                        principalTable: "Interessada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    LeilaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lance_Interessada_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Interessada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorInicial = table.Column<double>(type: "float", nullable: false),
                    InicioPregao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminoPregao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GanhadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leiloes_Lance_GanhadorId",
                        column: x => x.GanhadorId,
                        principalTable: "Lance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interessada",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Fulano de Tal" },
                    { 2, "Mariana Mary" },
                    { 3, "Sicrana Silva" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "InteressadaId", "Senha" },
                values: new object[,]
                {
                    { 3, "admin@example.org", null, "123" },
                    { 1, "fulano@example.org", 1, "123" },
                    { 2, "mariana@example.org", 2, "456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdInteressada",
                table: "Favoritos",
                column: "IdInteressada");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_ClienteId",
                table: "Lance",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_LeilaoId",
                table: "Lance",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_GanhadorId",
                table: "Leiloes",
                column: "GanhadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InteressadaId",
                table: "Usuarios",
                column: "InteressadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Leiloes_LeilaoId",
                table: "Favoritos",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Leiloes_LeilaoId",
                table: "Lance",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Interessada_ClienteId",
                table: "Lance");

            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Leiloes_LeilaoId",
                table: "Lance");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Interessada");

            migrationBuilder.DropTable(
                name: "Leiloes");

            migrationBuilder.DropTable(
                name: "Lance");
        }
    }
}
