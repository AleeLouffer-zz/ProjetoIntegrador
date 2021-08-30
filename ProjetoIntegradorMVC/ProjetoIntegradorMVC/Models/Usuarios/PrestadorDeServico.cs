using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class PrestadorDeServico : Usuario
    { 
        public List<string> Servicos { get; set; }
        public List<Decimal> ContasAReceber { get; set; }
    }
}
