using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class PessoaJuridica : Pessoa
    {
        public string NomeFantasia { get; set; }
    }
}
