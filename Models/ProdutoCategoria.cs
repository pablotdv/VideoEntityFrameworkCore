using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("ProdutosCategorias")]
    public class ProdutoCategoria
    {
        [Key]
        public Guid ProdutoCategoriaId { get; set; }

        [Required]
        [Display(Name ="Produto")]
        public Guid ProdutoId { get; set; }

        [Required]
        [Display(Name ="Categoria")]
        public Guid CategoriaId { get; set; }

        [ForeignKey(nameof(ProdutoId))]
        public virtual Produto Produto { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public virtual Categoria Categoria { get; set; }
    }
}
