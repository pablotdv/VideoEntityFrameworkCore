using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class PessoaFisica : Pessoa
    {
        [Required]
        public Sexo Sexo { get; set; }
    }
}
