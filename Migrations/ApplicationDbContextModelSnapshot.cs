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

namespace VideoEntityFrameworkCore.Migrations
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Cliente", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<DateTime>("ClienteDesde");

                    b.HasKey("PessoaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<string>("Atividade")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PessoaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Pessoa", b =>
                {
                    b.Property<Guid>("PessoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("ProdutoGrupoId");

                    b.Property<decimal>("Valor");

                    b.HasKey("ProdutoId");

                    b.HasIndex("ProdutoGrupoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.ProdutoCategoria", b =>
                {
                    b.Property<Guid>("ProdutoCategoriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoriaId");

                    b.Property<Guid>("ProdutoId");

                    b.HasKey("ProdutoCategoriaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosCategorias");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.ProdutoGrupo", b =>
                {
                    b.Property<Guid>("ProdutoGrupoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ProdutoGrupoId");

                    b.ToTable("ProdutosGrupos");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("VideoEntityFrameworkCore.Models.Pessoa");

                    b.Property<int>("Sexo");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("VideoEntityFrameworkCore.Models.Pessoa");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.ToTable("Pessoas");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Cliente", b =>
                {
                    b.HasOne("VideoEntityFrameworkCore.Models.Pessoa", "Pessoa")
                        .WithOne("Cliente")
                        .HasForeignKey("VideoEntityFrameworkCore.Models.Cliente", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VideoEntityFrameworkCore.Models.Fornecedor", b =>
                {
                    b.HasOne("VideoEntityFrameworkCore.Models.Pessoa", "Pessoa")
                        .WithOne("Fornecedor")
                        .HasForeignKey("VideoEntityFrameworkCore.Models.Fornecedor", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
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
