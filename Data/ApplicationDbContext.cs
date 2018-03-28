using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoEntityFrameworkCore.Models;

namespace VideoEntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ProdutoGrupo> ProdutosGrupos { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        public DbSet<PessoaFisica> PessoasFisicas { get; set; }

        public DbSet<ProdutoCategoria> ProdutosCategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoCategoria>()
                .HasKey(bc => new { bc.ProdutoId, bc.CategoriaId });
        }
    }
}
