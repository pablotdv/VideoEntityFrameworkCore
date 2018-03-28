using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class ProdutoCategoria
    {
        public Guid ProdutoId { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
