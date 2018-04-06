using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [ForeignKey(nameof(Pessoa))]
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Atividade { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
