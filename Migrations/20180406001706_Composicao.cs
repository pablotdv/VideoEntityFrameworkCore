using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VideoEntityFrameworkCore.Migrations
{
    public partial class Composicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    ClienteDesde = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Clientes_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    Atividade = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
