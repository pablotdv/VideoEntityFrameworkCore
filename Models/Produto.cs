using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [Required]
        [Display(Name = "Grupo do produto")]
        public Guid ProdutoGrupoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [ForeignKey(nameof(ProdutoGrupoId))]
        public virtual ProdutoGrupo ProdutoGrupo { get; set; }

        [InverseProperty(nameof(ProdutoCategoria.Produto))]
        public virtual ICollection<ProdutoCategoria> Categorias { get; set; }
    }
}
