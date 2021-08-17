using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class PrestadorDeServico : IUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<string> Servicos { get; set; }
        public List<Decimal> ContasAReceber { get; set; }
    }
}
