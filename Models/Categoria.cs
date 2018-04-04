using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [InverseProperty(nameof(ProdutoCategoria.Categoria))]
        public virtual ICollection<ProdutoCategoria> Produtos { get; set; }
    }
}
