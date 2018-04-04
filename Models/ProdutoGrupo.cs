using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("ProdutosGrupos")]
    public class ProdutoGrupo
    {
        [Key]
        public Guid ProdutoGrupoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Produto.ProdutoGrupo))]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
