using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [ForeignKey(nameof(Pessoa))]
        public Guid PessoaId { get; set; }

        public DateTime ClienteDesde { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
