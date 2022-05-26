using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class MotoristaViewModel
    {
        public int Codigo { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
    }
}
