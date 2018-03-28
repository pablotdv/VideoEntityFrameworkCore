using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        public Guid ProdutoGrupoId { get; set; }

        public string Nome { get; set; }
        public decimal Valor { get; set; }


        public virtual ProdutoGrupo ProdutoGrupo { get; set; }

        public virtual ICollection<ProdutoCategoria> Categorias { get; set; }
    }
}
