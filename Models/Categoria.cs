using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<ProdutoCategoria> Produtos { get; set; }
    }
}
