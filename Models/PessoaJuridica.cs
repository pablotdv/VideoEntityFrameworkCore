using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }
    }
}
