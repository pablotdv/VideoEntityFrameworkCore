﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using VideoEntityFrameworkCore.Data;
using VideoEntityFrameworkCore.Models;

namespace VideoEntityFrameworkCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Pessoa", b =>
                {
                    b.Property<Guid>("PessoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfCnpj");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Nome");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<Guid>("ProdutoGrupoId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoGrupoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.ProdutoCategoria", b =>
                {
                    b.Property<Guid>("ProdutoId");

                    b.Property<Guid>("CategoriaId");

                    b.HasKey("ProdutoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ProdutosCategorias");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.ProdutoGrupo", b =>
                {
                    b.Property<Guid>("ProdutoGrupoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("ProdutoGrupoId");

                    b.ToTable("ProdutosGrupos");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("VideoEntityFrameworkCore.Models.Pessoa");

                    b.Property<int>("Sexo");

                    b.ToTable("PessoaFisica");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("VideoEntityFrameworkCore.Models.Pessoa");

                    b.Property<string>("NomeFantasia");

                    b.ToTable("PessoaJuridica");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Produto", b =>
                {
                    b.HasOne("VideoEntityFrameworkCore.Models.ProdutoGrupo", "ProdutoGrupo")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoGrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.ProdutoCategoria", b =>
                {
                    b.HasOne("VideoEntityFrameworkCore.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VideoEntityFrameworkCore.Models.Produto", "Produto")
                        .WithMany("Categorias")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
