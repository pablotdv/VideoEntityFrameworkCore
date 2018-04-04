using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }
    }
}
