using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VideoEntityFrameworkCore.Data.Migrations
{
    public partial class Heranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    CpfCnpj = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
