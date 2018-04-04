using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VideoEntityFrameworkCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    CpfCnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sexo = table.Column<int>(nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosGrupos",
                columns: table => new
                {
                    ProdutoGrupoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosGrupos", x => x.ProdutoGrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    ProdutoGrupoId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_ProdutosGrupos_ProdutoGrupoId",
                        column: x => x.ProdutoGrupoId,
                        principalTable: "ProdutosGrupos",
                        principalColumn: "ProdutoGrupoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosCategorias",
                columns: table => new
                {
                    ProdutoCategoriaId = table.Column<Guid>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosCategorias", x => x.ProdutoCategoriaId);
                    table.ForeignKey(
                        name: "FK_ProdutosCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosCategorias_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoGrupoId",
                table: "Produtos",
                column: "ProdutoGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCategorias_CategoriaId",
                table: "ProdutosCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCategorias_ProdutoId",
                table: "ProdutosCategorias",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "ProdutosCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ProdutosGrupos");
        }
    }
}
