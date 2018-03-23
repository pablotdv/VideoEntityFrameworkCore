using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoEntityFrameworkCore.Models
{
    public class Pessoa
    {
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
    }
}
